from airflow import DAG
from datetime import datetime
from airflow.operators.python import PythonOperator
import os
try:
    from airflow.providers.common.sql.operators.sql import SQLExecuteQueryOperator
    from airflow.providers.microsoft.mssql.hooks.mssql import MsSqlHook
except ImportError:
    pytest.skip("MSSQL provider not available", allow_module_level=True)
from airflow.hooks.base import BaseHook
from airflow.utils.log.logging_mixin import LoggingMixin
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.base import MIMEBase
from email import encoders
import logging
import pyodbc
from itertools import islice

log = LoggingMixin().log
CUR_DIR = '/opt/airflow/dags/data'

default_args = {
    'owner': 'airflow',
    'start_date': datetime(2025, 4, 24)
}
dag=DAG(
    dag_id='DAG-LoadData',
    default_args=default_args,                                
    catchup=False
)  

particulier=r"""INSERT INTO Particulier(
    code_agence, client_radical, prenom, nom, date_naissance, presume, num_acte_naissance, acte_naissance, sexe, nationalite, pays_naissance, 
    wilaya_naissance, commune_naissance, prenom_pere, prenom_mere, nom_mere, etat_civil, nom_conjoint, profession, revenu, adresse, adresse_wilaya, 
    adresse_commune, type_doc, num_doc, pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique, date_loading)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"""

entreprise=r"""INSERT INTO Entreprise
(code_agence, client_radicale, date_creation, sigle, adresse_activite, wilaya_activite, commune_activite, adresse_siege, wilaya_siege, commune_siege, forme_juridique, 
code_activite_principale, entite_publique, effectif, valeur_ajoute, chiffre_affaire, resultat_net, total_bilan, total_actif,capital_emis, reserve, raport_nouveau, 
capitaux, emprunt, excedent_brut, resultat_financier, date_bilan, type_doc, num_doc, pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique, date_loading)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); 
""" #35

entrepreneur=r"""INSERT INTO Entrepreneur
(code_agence, client_radicale, prenom, nom, date_naissance, presume, num_acte_naissance, acte_naissance, sexe, nationalite, pays_naissance, wilaya_naissance, 
commune_naissance, prenom_pere, prenom_mere, nom_mere, etat_civile, nom_conjoint, profession, revenu, adresse, adresse_wilaya, adresse_commune, type_doc, num_doc, 
pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique, fond_propre, recette, total_bilan, effectif, code_activite, adresse_activite, 
adresse_activite_wilaya, adresse_activite_commune, date_loading)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #39

entreprise_societe=r"""INSERT INTO Entreprise_Societe
(code_agence, client_radicale, num_sequentiel, nif, pourcentage_participation, date_pourcentage, designation_social, code_activite, forme_juridique, date_loading)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #9

entreprise_associe=r"""INSERT INTO Entreprise_Associe
(code_agence, client_radicale, num_sequentiel, type_personne, indicateur_etat, designation_sociale, sigle, date_creation, pays_residance, identification, 
pourcentage_participation, date_pourcentage, fonction, date_loading)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #13


entreprise_dirigeant=r"""INSERT INTO Entreprise_Dirigeant
(code_agence, client_radicale, num_sequentiel, identification, nom, prenom, fonction, pays_residance, Nationalite, date_loading)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #9

#sql=[particulier ,entrepreneur, entreprise, entreprise_societe, entreprise_associe, entreprise_dirigeant]
#nbColumns=[31, 35, 39, 9, 13, 9]


FILE_CONFIG = {
    "CR1": {"sql": particulier, "nb_cols": 31},
    "CR2": {"sql": entrepreneur, "nb_cols": 35},
    "CR3": {"sql": entreprise, "nb_cols": 39},
    "CR4": {"sql": entreprise_societe, "nb_cols": 9},
    "CR5": {"sql": entreprise_associe, "nb_cols": 13},
    "CR6": {"sql": entreprise_dirigeant, "nb_cols": 9}
}

def getSqlserverConnection():
    conn = BaseHook.get_connection("sqlserver")
    conn_str = (
        f"DRIVER={{ODBC Driver 18 for SQL Server}};"
        f"SERVER={conn.host},{conn.port};"
        f"DATABASE={conn.schema};"
        f"UID={conn.login};"
        f"PWD={conn.password};"
        f"TrustServerCertificate=yes"
    )
    return pyodbc.connect(conn_str)
    #hook = MsSqlHook(mssql_conn_id="sqlserver")
    #return hook.get_conn()


def insertDatabase(rows, database, sqlRequest, nbColumn, cursor, batch_size=100):
    valid_rows = []
    error_rows = []
    timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    error_file = os.path.join(CUR_DIR, f"rejected_rows_{timestamp}.txt")

    for row in rows:
        if len(row) != nbColumn:
            log.warning("⚠️ Line ignored: incorrect number of columns (%s)", len(row))
            continue

        row = row + [datetime.now()]   
        valid_rows.append(tuple(row))
        

        if len(valid_rows) == batch_size:
            try:
                cursor.executemany(particulier, valid_rows)
                database.commit()
                log.info("✅ Batch of %d rows successfully inserted", batch_size)
                valid_rows.clear()
                
            except Exception as e:
                database.rollback()
                log.error("❌ Failed to insert batch : %s", e)
                #try to insert line by line
                for row in valid_rows:
                    try:
                        cursor.execute(sqlRequest, row)
                        database.commit()
                    except Exception as single_e:
                        database.rollback()
                        error_detail = f"{str(single_e)}"
                        error_rows.append((row, error_detail))
                        log.error("❌ Row rejected: %s | Error: %s", row, error_detail)
                valid_rows.clear()

    #log.warning(valid_rows)
    #insert rest of valid rows
    if valid_rows:
        try:
            log.warning(valid_rows)
            cursor.executemany(particulier, valid_rows)
            database.commit()
            log.info("✅ Last batch of %d rows successfully inserted", len(valid_rows))
        except Exception as e:
            database.rollback()
            log.error("❌ Failed to insert the last batch : %s", e)
            for row in valid_rows:
                try:
                    cursor.execute(sqlRequest, row)
                    database.commit()
                except Exception as single_e:
                    database.rollback()
                    error_detail = f"{str(single_e)}"
                    error_rows.append((row, error_detail))
                    log.error("❌ Row rejected: %s | Error: %s", row, error_detail)

    if error_rows:
        with open(error_file, "w", encoding="utf-8") as f:
            for row, error in error_rows:
                row_str = "|".join(str(col) if col is not None else "" for col in row)
                f.write(f"{row_str} || Error: {error}\n")
        log.warning("⚠️ %d rows rejected, saved in %s", len(error_rows), error_file)
        send_error_email(error_file, len(error_rows))


def read_in_chunks(file_object, chunk_size=1000):
    while True:
        lines = list(islice(file_object, chunk_size))
        if not lines:
            break
        yield lines

def readFile():
    agencies=['161','162','163','164','165','166'] 
    todayDate=datetime.now().strftime("%d%m")

    database=getSqlserverConnection()
    cursor = database.cursor()
            
    for agency in agencies:
        for file_code, config in FILE_CONFIG.items():
            
            filename = f"{agency}2411{file_code}" #{todayDate}
            file_path = os.path.join(CUR_DIR, filename) #1612411CR1
            
            if not os.path.exists(file_path):
                log.error(f"🚫 File not found: {filename}")
                continue

            with open(file_path, 'r') as file:
                for chunk in read_in_chunks(file, chunk_size=1000):
                    batch_rows = []
                    for line in chunk:
                        columns= line.split('|')
                 
                        if (file_code =='CR1' and len(columns)==31) :
                            columns[30] = columns[30].strip()[:26]

                        batch_rows.append(columns)

                    insertDatabase(batch_rows , database, config["sql"] , config["nb_cols"], cursor)     
            
            log.info(f"File uploaded successfully: {filename}")

        
    cursor.close()
    database.close()
        
def send_error_email(error_file, nb_errors):
    # mail configuration
    sender_email = "gouby.ines@nhb.dz"
    receiver_email = "gouby.ines@nhb.dz"
    smtp_server = "10.100.130.9"
    smtp_port = 25

    subject = f"🚨 SQL Import: {nb_errors} rows rejected"
    body = f"""Hello,
        {nb_errors} rows were rejected during data loading.
        You will find the details of the errors in the attached file.
        File: {os.path.basename(error_file)}

        Best regards,
        ETL Script
        """

    # Message
    message = MIMEMultipart()
    message["From"] = sender_email
    message["To"] = receiver_email
    message["Subject"] = subject

    message.attach(MIMEText(body, "plain"))

    # join error file
    try:
        with open(error_file, "rb") as f:
            part = MIMEBase("application", "octet-stream")
            part.set_payload(f.read())
            encoders.encode_base64(part)
            part.add_header("Content-Disposition", f"attachment; filename={os.path.basename(error_file)}")
            message.attach(part)
    except Exception as e:
        log.error("❌ Failed to attach error file : %s", e)
        return
    # send
    try:
        with smtplib.SMTP(smtp_server, smtp_port) as server:
            server.starttls()
          #  server.login(smtp_username, smtp_password)
            server.sendmail(sender_email, receiver_email, message.as_string())
        log.info("📧 Error email sent to %s", receiver_email)
    except Exception as e:
        log.error("❌ Failed to send email : %s", e)






load_data = PythonOperator(
    task_id='load_data',
    python_callable=readFile,
    dag=dag,
)

load_data 
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
import pyodbc
from airflow.utils.log.logging_mixin import LoggingMixin
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.base import MIMEBase
from email import encoders
import logging

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

personne_physique=r"""INSERT INTO Personne_Physique(
    code_agence, client_radical, prenom, nom, date_naissance, presume, num_acte_naissance, acte_naissance, sexe, nationalite, pays_naissance, 
    wilaya_naissance, commune_naissance, prenom_pere, prenom_mere, nom_mere, etat_civil, nom_conjoint, profession, revenu, adresse, adresse_wilaya, 
    adresse_commune, type_doc, num_doc, pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique
    )
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"""

personne_moral=r"""INSERT INTO Personne_Morale
(code_agence, client_radicale, date_creation, sigle, adresse_activite, wilaya_activite, commune_activite, adresse_siege, wilaya_siege, commune_siege, forme_juridique, 
code_activite_principale, entite_publique, effictif, valeur_ajoute, chiffre_affaire, resultat_net, total_bilan, total_actif,capital_emis, reserve, raport_nouveau, 
capitaux, emprunt, excedent_brut, resultat_financier, date_bilan, type_doc, num_doc, pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); 
""" #35

entrepreneur_individuel=r"""INSERT INTO Entrepreneur_Individuel
(code_agence, client_radicale, prenom, nom, date_naissance, presume, num_acte_naissance, acte_naissance, sexe, nationalite, pays_naissance, wilaya_naissance, 
commune_naissance, prenom_pere, prenom_mere, nom_mere, etat_civile, nom_conjoint, profession, revenu, adresse, adresse_wilaya, adresse_commune, type_doc, num_doc, 
pays_emission, entite_emettrice, date_expiration, nif, cle_intermediaire, cle_onomastique, fond_propre, recette, total_bilan, effictif, code_activite, adresse_activite, 
adresse_activite_wilaya, adresse_activite_commune)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #39

personne_morale_societe=r"""INSERT INTO Personne_Morale_Societe
(code_agence, client_radicale, num_sequentiel, nif, pourcentage_participation, date_pourcentage, designation_social, code_activite, forme_juridique)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?);""" #9

personne_morale_associe=r"""INSERT INTO Personne_Morale_Associe
(code_agence, client_radicale, num_sequentiel, type_personne, indicateur_etat, designation_sociale, sigle, date_creation, pays_residance, identification, 
pourcentage_participation, date_pourcentage, fonction)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);""" #13


personne_morale_dirigeant=r"""INSERT INTO Personne_Morale_Dirigeant
(code_agence, client_radicale, num_sequentiel, identification, nom, prenom, fonction, pays_residance, Nationalite)
VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?);""" #9

sql=[personne_physique,entrepreneur_individuel, personne_moral, personne_morale_societe, personne_morale_associe, personne_morale_dirigeant]
nbColumns=[31,35,39, 9,13,9]

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



def insertDatabase(rows, database, sqlRequest, nbColumn, cursor, batch_size=100):
    valid_rows = []
    error_rows = []
    timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    error_file = os.path.join(CUR_DIR, f"rejected_rows_{timestamp}.txt")

    for columns in rows:
        if len(columns) != nbColumn:
            log.warning("⚠️ Ligne ignorée : nombre de colonnes incorrect (%s)", len(columns))
            continue
           
        valid_rows.append(tuple(columns))
        

        if len(valid_rows) == batch_size:
            try:
                cursor.executemany(sqlRequest, valid_rows)
                database.commit()
                log.info("✅ Batch de %d lignes inséré avec succès.", batch_size)
                valid_rows.clear()
                
            except Exception as e:
                database.rollback()
                log.error("❌ Échec de l'insertion d'un batch : %s", e)
                #try to insert line by line
                for row in valid_rows:
                    try:
                        cursor.execute(sqlRequest, row)
                        database.commit()
                    except Exception as single_e:
                        database.rollback()
                        error_detail = f"{str(single_e)}"
                        error_rows.append((row, error_detail))
                        log.error("❌ Ligne rejetée: %s | Erreur: %s", row, error_detail)
                valid_rows.clear()

    #log.warning(valid_rows)
    #insert rest of valid rows
    if valid_rows:
        try:
            cursor.executemany(sqlRequest, valid_rows)
            database.commit()
            log.info("✅ Dernier batch de %d lignes inséré.", len(valid_rows))
        except Exception as e:
            database.rollback()
            log.error("❌ Échec de l'insertion du dernier batch : %s", e)
            for row in valid_rows:
                try:
                    cursor.execute(sqlRequest, row)
                    database.commit()
                except Exception as single_e:
                    database.rollback()
                    error_detail = f"{str(single_e)}"
                    error_rows.append((row, error_detail))
                    log.error("❌ Ligne rejetée: %s | Erreur: %s", row, error_detail)

    if error_rows:
        with open(error_file, "w", encoding="utf-8") as f:
            for row, error in error_rows:
                row_str = "|".join(str(col) if col is not None else "" for col in row)
                f.write(f"{row_str} || Erreur: {error}\n")
        log.warning("⚠️ %d lignes rejetées sauvegardées dans %s", len(error_rows), error_file)
        send_error_email(error_file, len(error_rows))


def send_error_email(error_file, nb_errors):
    # mail configuration
    sender_email = "gouby.ines@nhb.dz"
    receiver_email = "gouby.ines@nhb.dz"
    smtp_server = "10.100.130.9"
    smtp_port = 25
  

    subject = f"🚨 Import SQL : {nb_errors} lignes rejetées"
    body = f"""Bonjour,
        {nb_errors} lignes ont été rejetées lors du chargement des données.
        Vous trouverez le détail des erreurs en pièce jointe.
        Fichier: {os.path.basename(error_file)}
        Cordialement,
        Le script ETL
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
        log.error("❌ Erreur lors de la lecture du fichier : %s", e)
        return
    # send
    try:
        with smtplib.SMTP(smtp_server, smtp_port) as server:
            server.starttls()
          #  server.login(smtp_username, smtp_password)
            server.sendmail(sender_email, receiver_email, message.as_string())
        log.info("📧 Email d'erreurs envoyé à %s", receiver_email)
    except Exception as e:
        log.error("❌ Impossible d'envoyer l'email : %s", e)



def readFile():
    agency_id=['161'] #,'162','163','164','165','166'
    file_id=['CR1'] #,'CR2','CR3','CR4','CR5','CR6'
    todayDate=datetime.now().strftime("%d%m")

    database=getSqlserverConnection()

    for agency in agency_id:
        for index, file in enumerate(file_id):
            batch_rows = []
            filename = f"{agency}{todayDate}{file}"
            file_path = os.path.join(CUR_DIR, "1612411CR1") #1612411CR1
            
            if not os.path.exists(file_path):
                log.error(f"🚫 File not found: {filename}")
                continue
            
            cursor = database.cursor()

            with open(file_path, 'r') as file:
                lines = file.readline()
                while lines:
                    columns= lines.split('|')
                 
                    if (file_id[index] =='CR1' and len(columns)==31) :
                        columns[30] = columns[30].strip()[:26]

                    batch_rows.append(columns)
                    lines = file.readline()

            insertDatabase(batch_rows , database, sql[index] , nbColumns[index], cursor)     
            log.info(f"File uploaded: {filename}")

        

load_data = PythonOperator(
    task_id='load_data',
    python_callable=readFile,
    dag=dag,
)

load_data 
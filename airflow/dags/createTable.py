from airflow.operators.python import PythonOperator
try:
    from airflow.providers.common.sql.operators.sql import SQLExecuteQueryOperator
    from airflow.providers.microsoft.mssql.hooks.mssql import MsSqlHook
except ImportError as e:
    raise ImportError("❌ Le provider MSSQL n'est pas installé : installez `apache-airflow-providers-microsoft-mssql`") from e
from airflow import DAG
from datetime import datetime
from airflow.providers.microsoft.mssql.hooks.mssql import MsSqlHook


def test_mssql_connection():
    try:
        hook = MsSqlHook(mssql_conn_id='sqlserver')
        result = hook.get_first("SELECT 1")
        print("✅ MSSQL connection successful. Result:", result)
    except Exception as e:
        print("❌ Connection failed:", str(e))
        raise

default_args = {
    'owner': 'airflow',
    'start_date': datetime(2025, 4, 24)
}

dag = DAG(
    dag_id='DAG-CreateTable',
    default_args=default_args,
    schedule='@once',
    catchup=False
)


test_conn = PythonOperator(
    task_id='test_sqlserver_connection',
    python_callable=test_mssql_connection,
    dag=dag,
)


create_table_PersonnePhysique_task = SQLExecuteQueryOperator(
        task_id="create_PersonnePhysique_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Personne_Physique')
            BEGIN
            CREATE TABLE Personne_Physique (
                code_agence nvarchar(5) NULL,
                client_radical int NULL,
                prenom varchar(50) NULL,
                nom varchar(50) NULL,
                date_naissance date NULL,
                presume bit NULL,
                num_acte_naissance int NULL,
                acte_naissance char(1) NULL,
                sexe int NULL,
                nationalite int NULL,
                pays_naissance nvarchar(5) NULL,
                wilaya_naissance nvarchar(5) NULL,
                commune_naissance int NULL,
                prenom_pere varchar(50) NULL,
                prenom_mere varchar(50) NULL,
                nom_mere varchar(50) NULL,
                etat_civile int NULL,
                nom_conjoint varchar(50) NULL,
                profession int NULL,
                revenu decimal(18,0) NULL,
                adresse varchar(100) NULL,
                adresse_wilaya int NULL,
                adresse_commune int NULL,
                type_doc nvarchar(5) NULL,
                num_doc varchar(20) NULL,
                pays_emission int NULL,
                enite_emitrice varchar(100) NULL,
                date_expiration date NULL,
                nif varchar(20) NULL,
                cle_intermidiaire varchar(26) NULL,
                cle_onomastique varchar(26) NULL
            );
            END
        """,
        dag=dag,
)
create_table_EntrepreneurIndividual_task = SQLExecuteQueryOperator(
        task_id="create_EntrepreneurIndividual_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Entrepreneur_Individuel')
            BEGIN
                CREATE TABLE Entrepreneur_Individuel (
                    code_agence int NULL,
                    client_radicale int NULL,
                    prenom varchar(50) NULL,
                    nom varchar(50) NULL,
                    date_naissance date NULL,
                    presume bit NULL,
                    num_acte_naissance int NULL,
                    acte_naissance char(1) NULL,
                    sexe int NULL,
                    nationalite int NULL,
                    pays_naissance int NULL,
                    wilaya_naissance int NULL,
                    commune_naissance int NULL,
                    prenom_pere varchar(50) NULL,
                    prenom_mere varchar(50) NULL,
                    nom_mere varchar(50) NULL,
                    etat_civile int NULL,
                    nom_conjoint varchar(50) NULL,
                    profession int NULL,
                    revenu decimal(18,0) NULL,
                    adresse varchar(100) NULL,
                    adresse_wilaya int NULL,
                    adresse_commune int NULL,
                    type_doc int NULL,
                    num_doc varchar(20) NULL,
                    pays_emission int NULL,
                    entite_emitrice varchar(20) NULL,
                    date_expiration date NULL,
                    nif varchar(20) NULL,
                    cle_intermidiaire varchar(26) NULL,
                    cle_onomastique varchar(26) NULL,
                    fond_propre decimal(18,0) NULL,
                    recette decimal(18,0) NULL,
                    total_bilan decimal(18,0) NULL,
                    effictif decimal(18,0) NULL,
                    code_activite int NULL,
                    adresse_activite varchar(100) NULL,
                    adresse_activite_wilaya int NULL,
                    adresse_activite_commune int NULL
                );
            END
        """,
       dag=dag,
    )


create_table_PersonneMorale_task = SQLExecuteQueryOperator(
        task_id="create_PersonneMorale_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Personne_Morale')
            BEGIN
                CREATE TABLE Personne_Morale (
                    code_agence int NULL,
                    client_radicale int NULL,
                    date_creation date NULL,
                    sigle varchar(20) NULL,
                    adresse_activite varchar(100) NULL,
                    wilaya_activite int NULL,
                    commune_activite int NULL,
                    adresse_siege varchar(100) NULL,
                    wilaya_siege int NULL,
                    commune_siege int NULL,
                    forme_juridique int NULL,
                    code_activite_principale int NULL,
                    entite_publique int NULL,
                    effictif decimal(18,0) NULL,
                    valeur_ajoute decimal(18,0) NULL,
                    chiffre_affaire decimal(18,0) NULL,
                    resultat_net decimal(18,0) NULL,
                    total_bilan decimal(18,0) NULL,
                    total_actif decimal(18,0) NULL,
                    capital_emis decimal(18,0) NULL,
                    reserve decimal(18,0) NULL,
                    raport_nouveau decimal(18,0) NULL,
                    capitaux decimal(18,0) NULL,
                    emprunt decimal(18,0) NULL,
                    excedent_brut decimal(18,0) NULL,
                    resultat_financier decimal(18,0) NULL,
                    date_bilan decimal(18,0) NULL,
                    type_doc int NULL,
                    num_doc varchar(20) NULL,
                    pays_emission int NULL,
                    enite_emitrice varchar(20) NULL,
                    date_expiration date NULL,
                    nif varchar(20) NULL,
                    cle_intermidiaire varchar(26) NULL,
                    cle_onomastique varchar(26) NULL
                );
            END
        """,
       dag=dag,
    )


create_table_PersonneMoraleDirigeant_task = SQLExecuteQueryOperator(
        task_id="create_PersonneMoraleDirigeant_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Personne_Morale_Dirigeant')
            BEGIN
                CREATE TABLE Personne_Morale_Dirigeant (
                    code_agence int NULL,
                    client_radicale int NULL,
                    num_sequentiel int NULL,
                    identification varchar(36) NULL,
                    nom varchar(50) NULL,
                    prenom varchar(50) NULL,
                    fonction int NULL,
                    pays_residance int NULL,
                    Nationalite int NULL
                );
            END
        """,
       dag=dag,
    )


create_table_PersonneMoraleAssocie_task = SQLExecuteQueryOperator(
        task_id="create_PersonneMoraleAssocie_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Personne_Morale_Associe')
            BEGIN
                CREATE TABLE Personne_Morale_Associe (
                    code_agence int NULL,
                    client_radicale int NULL,
                    num_sequentiel int NULL,
                    type_personne int NULL,
                    indicateur_etat char(1) NULL,
                    designation_sociale varchar(100) NULL,
                    sigle varchar(50) NULL,
                    date_creation date NULL,
                    pays_residance int NULL,
                    identification varchar(25) NULL,
                    pourcentage_participation decimal(18,0) NULL,
                    date_pourcentage date NULL,
                    fonction int NULL
                );
            END
        """,
       dag=dag,
    )



create_table_PersonneMoraleSociete_task = SQLExecuteQueryOperator(
        task_id="create_PersonneMoraleSociete_table",
        conn_id="sqlserver",
        sql=r"""
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Personne_Morale_Societe')
            BEGIN
                CREATE TABLE Personne_Morale_Societe (
                    code_agence int NULL,
                    client_radicale int NULL,
                    num_sequentiel int NULL,
                    nif varchar(20) NULL,
                    pourcentage_participation decimal(18,0) NULL,
                    date_pourcentage date NULL,
                    designation_social varchar(100) NULL,
                    code_activite int NULL,
                    forme_juridique int NULL
                );
            END
        """,
       dag=dag,
    )



test_conn >> create_table_PersonnePhysique_task >> create_table_EntrepreneurIndividual_task >> create_table_PersonneMorale_task
create_table_PersonneMoraleAssocie_task >> create_table_PersonneMoraleDirigeant_task >> create_table_PersonneMoraleSociete_task


#Step 1: Get files from server (PythonOperator or BashOperator for scp/wget/sftp)
#Step 2: Read file line-by-line and insert into SQL Server (PythonOperator)
#Step 3: Fetch inserted data from SQL Server and transform to XML (PythonOperator)
#Step 4: (Optional) Save XML locally or send it via email/API/etc. (PythonOperator)

# Your Daily Process Ideal for Airflow
#Every Day
# 1. Fetch new files from server
# 2. Parse & insert lines into SQL Server
# 3. Transform inserted data into XML
#Each of these steps can be cleanly handled by a PythonOperator inside an Airflow DAG, and you can:
#Add logging
#Enable notifications (e.g., if files are missing)
#Archive processed files
#Upload XML somewhere (API, email, etc.)


#def fetch_files_from_server():
    # Use `scp`, `sftp`, or a library like `paramiko` or `pysftp`
    # Example: os.system("scp user@server:/path/*.txt /opt/airflow/dags/data/")
   

#def read_and_insert_to_db():
    # Read each file, split lines, insert into SQL Server (pyodbc + BaseHook)
  

#def transform_to_xml():
    # Query data from database, use `xml.etree.ElementTree` to create XML
    

#with DAG('etl_files_to_db_and_xml', start_date=datetime(2025, 5, 1), schedule='@daily', catchup=False) as dag:
    
    #fetch_task = PythonOperator(task_id='fetch_files', python_callable=fetch_files_from_server )
    #insert_task = PythonOperator(task_id='insert_to_sqlserver',python_callable=read_and_insert_to_db)
    #xml_task = PythonOperator(task_id='transform_to_xml', python_callable=transform_to_xml)
    #fetch_task >> insert_task >> xml_task


#Why Airflow DAG is Better for Daily File Processing
#Criteria	                   Airflow DAG	                                             Pure Python Script
#Automation	                   Built-in scheduling (e.g., every day at 6 AM)	         You'd have to use cron or manually run it
#Retry on failure	           Automatic retries per task	                             You'd have to code this manually
#Logging & Monitoring	       Logs every run, track success/failure in UI	             Logs must be coded manually; harder to trace
#Modularity	                   Each step is a task (download → insert → transform)	     All steps tightly coupled in one script
#Error Isolation	           Errors isolated per task → easier debugging	             One failure can crash the whole script
#Connection management	       Use secure Airflow Connections (no credentials in code)	 You'd have to manage DB credentials manually
#Team & Production Friendly	   Works great in CI/CD and production environments	         Harder to scale and manage

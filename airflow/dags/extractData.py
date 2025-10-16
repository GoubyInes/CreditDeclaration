from airflow import DAG
from airflow.providers.sftp.hooks.sftp import SFTPHook
from airflow.operators.python import PythonOperator
from datetime import datetime, date, timedelta
import os
from airflow.operators.trigger_dagrun import TriggerDagRunOperator
from airflow.utils.log.logging_mixin import LoggingMixin
from airflow.utils.task_group import TaskGroup

logger = LoggingMixin().log

default_args = {
    'owner': 'airflow',
    'start_date': datetime(2025, 4, 24),
    'email': ['gouby.ines@nhb.dz'], # Monitoring & alertes
    'email_on_failure': True,
    'email_on_retry': False,
    'retries': 3,
    'retry_delay': timedelta(minutes=5)
}

dag=DAG(
    dag_id='DAG-ExtractData',
    default_args=default_args,
    #schedule='@daily',
    schedule_interval='0 23 * * *',
    catchup=False,
    doc_md="""
    ## DAG - ExtractData  
    Ce DAG extrait quotidiennement les fichiers de déclaration de crédits depuis les serveurs SFTP des agences.  
    **Étapes :**
    1. Création du répertoire local daté  
    2. Extraction des fichiers par agence  
    3. Déclenchement du DAG de chargement (`DAG-LoadData`)  
    """
)

staging_directory = '/opt/airflow/dags/data/' 
connexions=['achour_agency', 'beb_ezzouar_agency', 'oran_agency', 'setif_agency', 'constantine_agency', 'skikda_agency']
agencies=['161','162','163','164','165','166']
files=['SCL','SGL','OGL','CR1','CR2','CR3','CR4','CR5','CR6','CR']
current_time=datetime.now() 
directory_name=current_time.strftime("%d%m%y") 


def list_ftp_files(connexion, agency, staging_directory, directory_name):
    logger.info("Server : " + connexion) 
    file_date=agency+current_time.strftime("%m%d") #"0805"

    try:
        hook = SFTPHook(ssh_conn_id=connexion)
        filesRoot = hook.list_directory(path='/')

        if('home21') in filesRoot:
            filesHome = hook.list_directory(path='/home21')

            if('OUT') in filesHome:
                filesOUT = hook.list_directory(path='/home21/OUT')

                for file_name in files: 
                    file=file_date+file_name
                    if( file ) in filesOUT: 
                        remote_file_path = '/home21/OUT/'+file
                        local_file_path = os.path.join(staging_directory, directory_name, file) #staging_directory+directory_name+'/'+file
                        hook.retrieve_file(remote_full_path=remote_file_path, local_full_path=local_file_path)
                        logger.info(f"[{agency}] Downloading {file} from {connexion}")
                    else:
                        logger.error(f"[{agency}] Error while fetching file {file}")
                        
            else:
                logger.warning("Directory not found")
        else:
            logger.warning("Directory not found")
    except Exception as e: 
        logger.error(f"Cannot connect to {connexion}: {str(e)}")
           
def create_directory():
    full_path = os.path.join(staging_directory, directory_name)
    try:
        os.makedirs(full_path, exist_ok=True)
        logger.info(f"Directory {full_path} created successfully.")
    except Exception as e:
        logger.error(f"An error occurred: {e}")
        raise


directory = PythonOperator(
    task_id='directory',
    python_callable=create_directory,
    dag=dag,
)

with TaskGroup("extract_all_agencies", tooltip="Extraction agency") as extract_data:
    for i, connexion in enumerate(connexions):
        PythonOperator(
            task_id=f"extract_{agencies[i]}",
            python_callable=list_ftp_files,
            op_kwargs={
                'connexion': connexion,
                'agency': agencies[i],
                'staging_directory': staging_directory,
                'directory_name': directory_name
            }
        )


trigger_load_task = TriggerDagRunOperator(
    task_id="trigger_load_dag",
    trigger_dag_id="DAG-LoadData", 
    dag=dag,
    trigger_rule="all_success"
)

directory >> extract_data >> trigger_load_task



#Connexion à des sources distantes 	
#Traitement de fichiers plats	
#Contrôle des erreurs et logs	
#Chargement dans base relationnelle (SQL Server)	
#Structuration modulaire du code	
#Planification automatique via DAGs	
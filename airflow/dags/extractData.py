from airflow import DAG
from airflow.providers.sftp.hooks.sftp import SFTPHook
from airflow.operators.python import PythonOperator
from datetime import datetime, date, timedelta
import os
from airflow.operators.trigger_dagrun import TriggerDagRunOperator
from airflow.utils.log.logging_mixin import LoggingMixin

logger = LoggingMixin().log

default_args = {
    'owner': 'airflow',
    'start_date': datetime(2025, 4, 24),
    'email': ['gouby.ines@nhb.dz'], # Monitoring & alertes
    'email_on_failure': True,
    'email_on_retry': False,
    'retries': 1,
    'retry_delay': timedelta(minutes=5)
}

dag=DAG(
    dag_id='DAG-ExtractData',
    default_args=default_args,
    schedule='@once',
    catchup=False
)

current_dir = '/opt/airflow/dags/data/'
conn_id=['achour_agency', 'beb_ezzouar_agency', 'oran_agency', 'setif_agency', 'constantine_agency', 'skikda_agency']
agency_id=['161','162','163','164','165','166']
file_id=['SCL','SGL','OGL', 'CR1','CR2','CR3','CR4','CR5','CR6']
current_time=datetime.now()
directory_name=current_time.strftime("%d%m%y")

def list_ftp_files():
    for index, connexion in enumerate(conn_id): 
        logger.info("Server : " + connexion) #Logging
        logger.info("----------------------------------------------------------------------------------------")
        file_name=agency_id[index]+"0805"#+current_time.strftime("%m%d")
    
        try:
            hook = SFTPHook(ssh_conn_id=connexion)
            files = hook.list_directory(path='/')
            #print(f"Files in server : {files}")

            if('home21') in files:
                filesHome = hook.list_directory(path='/home21')

                if('OUT') in filesHome:
                    filesOUT = hook.list_directory(path='/home21/OUT')

                    for type in file_id: 
                        file=file_name+type 
                        if( file ) in filesOUT: 
                            remote_file_path = '/home21/OUT/'+file
                            local_file_path = current_dir+directory_name+'/'+file
                            hook.retrieve_file(remote_full_path=remote_file_path, local_full_path=local_file_path)
                            logger.info(f"File saved to {local_file_path}")
                            logger.info("----------------------------------------------------------------------------------------")

                        else:
                            logger.warning("File not found " + file)
                            logger.info("----------------------------------------------------------------------------------------")
                else:
                    logger.warning("Directory not found.")
                    logger.info("----------------------------------------------------------------------------------------")
            else:
                logger.warning("Directory not found.")
                logger.info("----------------------------------------------------------------------------------------")
        except Exception as e: 
            logger.error("Cannot connect to "+connexion)
            logger.info("----------------------------------------------------------------------------------------")

def create_directory():
    try:
        os.mkdir(current_dir+directory_name)
        logger.info(f"Directory '{directory_name}' created successfully.")
    except FileExistsError:
        logger.error(f"Directory '{directory_name}' already exists.")
    except PermissionError:
        logger.error(f"Permission denied: Unable to create '{directory_name}'.")
    except Exception as e:
        logger.error(f"An error occurred: {e}")


list_files = PythonOperator(
    task_id='list_ftp_files',
    python_callable=list_ftp_files,
    dag=dag,
)
directory = PythonOperator(
    task_id='directory',
    python_callable=create_directory,
    dag=dag,
)

trigger_load_task = TriggerDagRunOperator(
    task_id="trigger_load_dag",
    trigger_dag_id="DAG-LoadData", 
    dag=dag,
)

directory >> list_files #>> trigger_load_task



#Connexion à des sources distantes 	
#Traitement de fichiers plats	
#Contrôle des erreurs et logs	
#Chargement dans base relationnelle (SQL Server)	
#Structuration modulaire du code	
#Planification automatique via DAGs	




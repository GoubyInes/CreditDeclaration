                                    #Step 1: Importing the right modules for your DAG
# # To initiate the DAG Object
from airflow import DAG
# Importing datetime and timedelta modules for scheduling the DAGs
from datetime import timedelta, datetime
# Importing operators 
from airflow.operators.empty import EmptyOperator



                                    #Step 2: Create default arguments for the DAG 
#Default arguments is a dictionary that we pass to airflow object, it contains the metadata of the DA   
# Initiating the default_args
default_args = {
        'owner' : 'airflow',
        'start_date' : datetime(2025, 4, 24)
}     


                                    #Step 3: Creating DAG Object
# Creating DAG Object
dag = DAG(dag_id='DAG-1',            
        default_args=default_args,
        schedule='@once',   
        catchup=False
    )   #is the time, how frequently our DAG will be triggered. It can be once, hourly, daily, weekly,  monthly

                                    #Step 4: Create tasks
start = EmptyOperator(task_id= 'start', dag = dag)  #A task is an instance of an operator. It has a unique identifier called task_id
end= EmptyOperator(task_id= 'end', dag = dag) 

                                    #Step 5: Setting up dependencies for the DAG.

start >> end 
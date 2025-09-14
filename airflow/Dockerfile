# Utilise l'image officielle Airflow
FROM apache/airflow:3.0.0

# Installe MSSQL Provider dans l'image
RUN pip install --no-cache-dir apache-airflow-providers-microsoft-mssql
RUN pip install pyjwt requests

RUN pip install paramiko scp
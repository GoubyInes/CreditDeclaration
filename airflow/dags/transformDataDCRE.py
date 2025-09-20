
import xml.etree.ElementTree as ET
from airflow import DAG
from airflow.operators.python import PythonOperator
from datetime import datetime, date
import os
try:
    from airflow.providers.common.sql.operators.sql import SQLExecuteQueryOperator
    from airflow.providers.microsoft.mssql.hooks.mssql import MsSqlHook
except ImportError:
    pytest.skip("MSSQL provider not available", allow_module_level=True)
from airflow.hooks.base import BaseHook
import pyodbc
from airflow.utils.log.logging_mixin import LoggingMixin


CUR_DIR = '/opt/airflow/dags/data/'

default_args = {
    'owner': 'airflow',
    'start_date': datetime(2025, 4, 24)
}

dag=DAG(
    dag_id='DAG-TransformDataDCRE',
    default_args=default_args,
    schedule='@once',
    catchup=False
)

current_time=datetime.now()
code=''
type="Particulier" 


def create_xml():
        physic_person_list = fetch_personne_physique()
        physic_person_list = physic_person_list.applymap(lambda x: x.strip() if isinstance(x, str) else x)
        
        if(type=="Particulier"):
           code="001"
        if(type=="Entrepreneur"):
          code="002"
        if(type=="Entreprise"):
          code="003"

        crem=ET.Element("crem")
        crem = ET.SubElement(crem, "crem")
        
        #control
        c2=ET.Element("c2")
        c2 = ET.SubElement(c2, "c2")
        c2=ET.SubElement(crem,"c2") 
        #control attribute
        c2.set('c21', "032") #id banq
        c2.set('c22', "032") #id banq
        c2.set('c23', current_time.strftime("%Y-%m-%dT%H:%M:%S")) #date
        c2.set('c24', current_time.strftime("%y%m%d")+"001") #date + id file
        c2.set('c25', "111") #id banq
        tree=ET.ElementTree(c2)

        #content
        c3=ET.Element("c3")
        c3 = ET.SubElement(c3, "c3")
        c3=ET.SubElement(crem,"c3") 
        
        for _,row in physic_person_list.iterrows(): 

          c31=ET.SubElement(c3,"c31")  #Déclaration des débits /Contenu du Fichier DCRE
          c31.set("s1",'') #Date de la déclaration
          #Information du crédit
          s2=ET.SubElement(c31,"s2")
          d32=ET.SubElement(s2,"d32") #Identification du débiteur
          d32.text=""
          tree = ET.ElementTree(32)

          s11=ET.SubElement(s2,"s11") #Liste des crédits
          for i in [0,1]:
            s20=ET.SubElement(s11,"s20") 
            s20.set("s102",'niveau_responsabilite') #TG001 : Niveau de Responsabilité
            s20.set("s129",'identifiant_plafond') #Identifiant du Plafond (null possible)
            s20.set("s128",'numero_contrat') #Numéro du contrat de crédit
            s20.set("s111",'monnaie') #TG252 : Code monnaies
            s20.set("s113",'num_identite_bancaire') #Numéro d’identité bancaire (null possible)
            s20.set("s108",'pays_agence') #TG006 : Code Pays de l'agence
            s20.set("s114",'code_agence') #Code agence de l’établissement déclarant
            s20.set("s131",'wilaya_agence') #TG220 : Code Wilaya du bénéficiaire de crédit
            s20.set("s115",'activite') #TG095 : Code d’activité (null possible)
            s20.set("s107",'type_credit') #Type de crédit TG004
            s20.set("s103",'situation') #Situation du débiteur / crédit TG002
            s20.set("s104",'classe_retard') #TG026 : Classe de retard du crédit
            s20.set("s105",'duree_initiale') #TG251 : Durée de crédit initiale
            s20.set("s106",'duree_restante') #TG251 : Durée de crédit restante
            s20.set("s117",'accorde') #Crédit accordé
            s20.set("s101",'encours') #Encours hors intérêts courus
            s20.set("s119",'cout_total') #Coût total du crédit
            s20.set("s110",'montant_mensualite') #Montant de la Mensualité (null possible)
            s20.set("s118",'taux_interet') #Taux d’intérêt (null possible)
            s20.set("s120",'date_impaye') #Date de la constatation de l’impayé (null possible)
            s20.set("s130",'nb_echeance_impayee') #Nombre d’échéances impayées (null possible)
            s20.set("s126",'interet_courus') #Intérêts courus 
            s20.set("s121",'montant_capital_nrecouvre') #Montant de capital non recouvré (null possible)
            s20.set("s122",'montant_interet_nrecouvre') #Montant des intérêts non recouvrés (null possible)
            s20.set("s123",'date_rejet') #Date du rejet (null possible)
            s20.set("s124",'date_octroi') #Date d’octroi du crédit (null possible)
            s20.set("s125",'date_expiration') #Date d’expiration du crédit (null possible)
            
            s127=ET.SubElement(s20,"s127") #Notation du crédit
            s127.set("d391",'code_notation') #Notation TG224
            s127.set("d392",'organisme_notation') #Organisme de notation TG212 
            s127.set("d393",'date_notation') #Date de notation
            tree = ET.ElementTree(s127) 

            s109=ET.SubElement(s20,"s109") #Liste de garanties
            g=ET.SubElement(s109,"g") #Garantie
            g.set("g1",'type_garantie') #TG005 : Types de garanties
            g.set("g2",'montant_garantie') #Montant de la garantie prise
            tree = ET.ElementTree(s109)


            s112=ET.SubElement(s20,"s112") #Liste de Caractéristiques spéciales 
            k=ET.SubElement(s112,"k")
            k.set("k1",'operation') #Caractéristique de l’opération TG027
            k.set("k2",'descriptif_operation') #Descriptif de la Caractéristique de l’opération
            tree = ET.ElementTree(s112)
            
            tree = ET.ElementTree(s20)

          tree = ET.ElementTree(s11)

          tree = ET.ElementTree(s2)
          tree = ET.ElementTree(c31)


        tree=ET.ElementTree(c3)
        tree=ET.ElementTree(crem)
        tree.write(CUR_DIR+"dcre.xml", encoding ='utf-8', xml_declaration = True)

def fetch_personne_physique():
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Physique")
    #records = hook.get_records(sql="SELECT * FROM Personne_Physique")
    #for row in records:#print(row)  
    return records



cred_xmlFile = PythonOperator(
    task_id='cred_xmlFile',
    python_callable=create_xml,
    dag=dag,
)

cred_xmlFile 

#<crem xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" c1="1.0">
#<c2 c21="032" c22="032" c23="2024-07-08T14:55:01" c24="20240708174" c25="111"/>

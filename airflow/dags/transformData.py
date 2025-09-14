
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
    dag_id='DAG-TransformData',
    default_args=default_args,
    schedule='@monthly',
    catchup=False
)

current_time=datetime.now()
code=''
type="Particulier" 


def create_xml():
        physic_person_list = fetch_personne_physique()
        moral_person_list = fetch_personne_morale()
        individual_entrepronor_list = fetch_entrepreneur_individuel()

        physic_person_list = physic_person_list.applymap(lambda x: x.strip() if isinstance(x, str) else x)
        
        if(type=="Particulier"):
           code="001"
        if(type=="Entrepreneur"):
          code="002"
        if(type=="Entreprise"):
          code="003"

        crem=ET.Element("crem")
        
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

          c32=ET.SubElement(c3,"c32")  #Déclaration des débits /Contenu du Fichier DDEB
          d1=ET.SubElement(c32,"d1")  
          d1.set('d31',code) # Code type de débiteur TG048 001 particulier 002 entreprneur 003 entreprise
          d1.set('d33', str(row['client_radical'])) #Référence interne aux BEF id interne du débiteur dans lq banq
          d1.set('d35',str(row['pays_naissance'])) #Code ISO numérique de pays de naissance / création TG006
          # Nom du débiteur / Désignation Sociale
          if(code=='001') : 
            d1.set('d34',row['nom']) 
          elif (code=='002'): 
             d1.set('d34',row['sigle']) 

          # Changement de clé / Changement des débiteurs type U
          if(code=='001'):
            d1.set('d38',row['nom']+' '+row['prenom']) 
          if(code=='002'):
            d1.set('d38',row['designation'])
          if(code=='003'):
            d1.set('d38',row['sigle']) 

          d1.set('xsi:type',"I") #I: Déclaration d’un nouveau débiteur, U: Déclaration corréctive
          tree = ET.ElementTree(d1)

          d32=ET.SubElement(c32,"d32") # Identification fiscale du débiteur A REVOIR
          if row['nif'] :
           d32.text=row['nif']
           d32.set("xsi:type","i1")
          elif row['cle_intermediaire']:
           d32.text=row['cle_intermediaire'] 
           d32.set("xsi:type","i2")
          else:
           d32.text=row['cle_onomastique'] 
           d32.set("xsi:type","i3")
             
          tree = ET.ElementTree(d32)

          d37=ET.SubElement(c32,"d37") #Autres identifiants
          e=ET.SubElement(d37,"e")
          e.set("e1",row['type_doc']) #Type d’identifiant document TG049
          e.set("e2",row['num_doc']) #Numéro du document
          e.set("e3",str(row['pays_emission'])) #Pays d’émission TG006
          e.set("e4",row['entite_emettrice']) #Entité émettrice
          e.set("e5",row['date_expiration'].strftime('%Y-%m-%d')) #Date d’expiration
          tree = ET.ElementTree(d37)

       
          d36=ET.SubElement(c32,"d36") #Données descriptives du débiteur
          if code=='001':
            d36.set("xsi:type","t1")
          elif code=='002':
            d36.set("xsi:type","t2")
          else:
            d36.set("xsi:type","t3")
             
          #Description d’élément [d36] du type  [t1]: Particulier 
          if(code!="003"):
            d36.set("t11", row['date_naissance'].strftime('%Y-%m-%d')) #Date naissance
            d36.set("t12", row['prenom']) #Prenom
            d36.set("t13", row['nom']) #Nom
            d36.set("t14", str(row['num_acte_naissance'])) #Num acte de naissance
            d36.set("t15", str(row['presume'])) #Présumé ou non
            d36.set("t16", str(row['wilaya_naissance'])) #Wilaya de naissance TG220
            d36.set("t17", str(row['commune_naissance'])) #Commune de naissance
            d36.set("t18", str(row['sexe'])) #Genre  1:Masculin, 2:Féminin
            d36.set("t19", row['nom_conjoint']) #Nom conjoint obligatoire si t18=2 et t23=mariee ou veuve sin non disponible renseigner S/I 
            d36.set("t20", row['prenom_pere']) #Prénom pére, En cas d’absence de filiation dans l’état civil, renseigner par « sf »
            d36.set("t21", row['prenom_mere']) #Prénom mère, En cas d’absence de filiation dans l’état civil, renseigner par « sf »
            d36.set("t22", row['nom_mere']) #Nom mère de naissance, En cas d’absence de filiation dans l’état civil, renseigner par « sf »
            d36.set("t23", str(row['etat_civil'])) #Etat civil TG210
            d36.set("t24", str(row['profession'])) #Profession TG211
            d36.set("t25", str(row['revenu'])) #Revenu
            d36.set("t29", str(row['nationalite'])) #nationalité 1 ou 0

          #[t2]:t1 + Entrepreneur individuel
          if(code=="002"):
            d36.set("t27", str(row['fond_propre'])) #Fonds propre
            d36.set("t28", str(row['recette'])) #Recette
            d36.set("t303", row['adress_activite']) #Adresse activité
            d36.set("t305", str(row['code_activite'])) #Code activité TG095
            d36.set("t307", str(row['effectif'])) #Effectif 
            d36.set("t311", str(row['total_bilan'])) #Bilan

          #Description d’élément [d36] du type [t3]: Entreprise
          if(code=="003"):
            d36.set("t11", row['date_creation'].strftime('%Y-%m-%d')) #Date creation
            d36.set("t301", row['sigle']) #Sigle
            d36.set("t304", str(row['forme_juridique'])) #Forme juridique TG213
            d36.set("t305", str(row['code_activite_principale'])) #Activité principale
            d36.set("t306", str(row['entite_publique'])) #Entité publique TG096
            d36.set("t307", str(row['effectif'])) #Effectif
            d36.set("t308", str(row['valeur_ajoute'])) #Valeur ajoutée
            d36.set("t309", str(row['chiffre_affaire'])) #Chiffre d'affaire
            d36.set("t310", str(row['resultat_net'])) #Résultat net
            d36.set("t311", str(row['total_bilan'])) #Total bilan
            d36.set("t312", row['date_bilan'].strftime('%Y-%m-%d')) #Date bilan
            d36.set("t313", str(row['total_actif'])) #Total actifs non courants
            d36.set("t314", str(row['capital_emis'])) #Capital émis
            d36.set("t315", str(row['reserve'])) #Réserves
            d36.set("t316", str(row['report_nouveau'])) #Report à nouveau
            d36.set("t317", str(row['capitaux'])) #Capitaux propres
            d36.set("t318", str(row['emprunt'])) #Emprunts et dettes financières
            d36.set("t319", str(row['excedent_brut'])) #Excèdent Brut d’exploitation
            d36.set("t320", str(row['resultat_financier'])) #Résultat financier
      
          tree = ET.ElementTree(d36) 


          if(code!="003"):
            t26=ET.SubElement(c32,"t26") #Adresse t1 et t2
            t26.set("m1",row['adresse'])  
            t26.set("m2",str(row['adresse_wilaya']))#TG220
            t26.set("m3",str(row['adresse_commune']))#TG221
            tree = ET.ElementTree(t26)

          #suite t3
          if(type=="003"):
            t302=ET.SubElement(c32,"t302") #Adresse activité t3
            t302.set("m1",row['adresse_activite'])  
            t302.set("m2",str(row['wilaya_activite']))#TG220
            t302.set("m3",str(row['commune_activite']))#TG221
            tree = ET.ElementTree(t302)

            t303=ET.SubElement(c32,"t303") #Adresse Siège 
            t303.set("m1",row['adresse_siege'])  
            t303.set("m2",str(row['wilaya_siege']))#TG220
            t303.set("m3",str(row['commune_siege']))#TG221
            tree = ET.ElementTree(t303)

          
          if(code!="003"): #PersonneMoraleAssocie
            moral_person_associe_list= fetch_personne_morale_associe(row['client_radical'])
            t322=ET.SubElement(c32,"t322") #Liste de Groupe 
            for _,rowAss in moral_person_associe_list.iterrows(): 
              g3=ET.SubElement(t322,"g3")
              g3.set("e41",rowAss['nif']) #NIF de l’entreprise
              g3.set("e42",str(rowAss['pourcentage_participation'])) #Pourcentage de participation
              g3.set("e43",rowAss['date_pourcentage'].strftime('%Y-%m-%d')) #Date de participation
              g3.set("e44",rowAss['designation_social']) #Désignation Sociale
              g3.set("e45",str(rowAss['code_activite'])) #Code d’Activité TG095
              g3.set("e46",str(rowAss['forme_juridique'])) #Forme Juridique TG213
              tree = ET.ElementTree(g3)
            tree = ET.ElementTree(t322)
          
         
            #PersonneMoraleSociete
            moral_person_societe_list= fetch_personne_morale_associe(row['client_radical'])
            t323=ET.SubElement(c32,"t323") #Liste des associés de la société mère 
            for _,rowSoc in moral_person_societe_list.iterrows(): 
              h1=ET.SubElement(t323,"h1")
              h1.set("h11",str(rowSoc['type_personne'])) #Type de personne TG048
              h1.set("h20",str(rowSoc['indicateur_etat'])) #Indicateur de l’État
              h1.set("h12",rowSoc['designation_social']) #Nom / Désignation
              h1.set("h19",rowSoc['sigle']) #Prénom   /  Sigle
              h1.set("h13",rowSoc['date_creation']).strftime('%Y-%m-%d') #Date de naissance / création
              h1.set("h14",str(rowSoc['pays_residence'])) #Pays de Résidence TG006
              h1.set("h15",str(rowSoc['num_sequentiel'])) #Identifiant unique
              h1.set("h16",str(rowSoc['pourcentage_participation'])) #Pourcentage détenu
              h1.set("h17",rowSoc['date_pourcentage'].strftime('%Y-%m-%d')) #Date de prise de participation
              h1.set("h18",str(rowSoc['fonction'])) #Fonction TG215
              tree = ET.ElementTree(h1)
            tree = ET.ElementTree(t323)

         
            #PersonneMoraleDirigeant
            moral_person_dirigeant_list= fetch_personne_morale_dirigeant(row['client_radical'])
            t324=ET.SubElement(c32,"t324")
            for _,rowDir in moral_person_dirigeant_list.iterrows(): 
             j1=ET.SubElement(t324,"j1")
             j1.set("j11",rowDir['identification']) #Identifiant unique
             j1.set("j12",rowDir['nom']) #Nom
             j1.set("j13",rowDir['prenom']) #Prénom
             j1.set("j14",str(rowDir['fonction'])) #Fonction du dirigeant TG215
             j1.set("j15",str(rowDir['pays_residence'])) #Pays TG006
             j1.set("j16",str(rowDir['nationalite'])) #Nationalité TG006
             tree = ET.ElementTree(j1)
            tree = ET.ElementTree(t324)


          #d39=ET.SubElement(c32,"d39")  #Notation du débiteur 
          #d39.set("d391",row['']) #Notation TG224
          #d39.set("d392",row['']) #Organisme de notation TG212
          #d39.set("d393",row['']) #Date de notation
          #tree = ET.ElementTree(d39)
          tree = ET.ElementTree(c32)


        tree=ET.ElementTree(c3)
        tree=ET.ElementTree(crem)
        # write the tree into an XML file
        tree.write(CUR_DIR+"ddeb.xml", encoding ='utf-8', xml_declaration = True)

def fetch_personne_physique():
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Physique")
    #records = hook.get_records(sql="SELECT * FROM Personne_Physique")
    #for row in records:#print(row)  
    return records

def fetch_entrepreneur_individuel():
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Entrepreneur_Individuel") 
    return records

def fetch_personne_morale():
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Morale") 
    return records

def fetch_personne_morale_associe(id):
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Morale where client_radical= %s",parameters=(id)) # _Associe
    return records

def fetch_personne_morale_dirigeant(id):
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Morale where client_radical=%s",parameters=(id)) #_Dirigeant
    return records

def fetch_personne_morale_societe(id):
    hook = MsSqlHook(mssql_conn_id='sqlserver')
    records = hook.get_pandas_df(sql="SELECT * FROM Personne_Morale where client_radical=%s",parameters=(id)) #_Societe 
    return records

get_Personne_Physqiue = PythonOperator(
        task_id="get_personne_physique",
        python_callable=fetch_personne_physique,
        dag=dag
    )


deb_xmlFile = PythonOperator(
    task_id='deb_xmlFile',
    python_callable=create_xml,
    dag=dag,
)

get_Personne_Physqiue 

#<crem xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" c1="1.0">
#<c2 c21="032" c22="032" c23="2024-07-08T14:55:01" c24="20240708174" c25="111"/>
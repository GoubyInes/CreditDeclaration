// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/PersonnePhysique';
const PersonPhysicService = {
    getPersonPhysics: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createPersonPhysic: async (PersonPhysic) => {
       
        const value = {
            codeAgence: "001",
            clientRadical: "123", // Doit être un entier (int)
            prenom: "Ali",
            nom: "Benali",
            dateNaissance: "1990-01-01",
            presume: false,
            numActeNaissance: "123", // Doit être un nombre (pas string)
            sexe: "1", // OK si attendu char(1)
            nationalite: true, // DZ -> true (Algérien)
            paysNaissance: "012",
            wilayaNaissance: "01",
            communeNaissance: "001", // max 3 caractères
            prenomPere: "Mohamed",
            prenomMere: "Fatima",
            nomMere: "Amar",
            etatCivil: "001", // doit être <= 3 caractères
            profession: "001", // doit être 3 caractères max (pas "1001")
            revenu: "120000.00",
            adresse: "Alger",
            adresseWilaya: "01",
            adresseCommune: "001",
            typeDoc: "001",
            numDoc: "123456789",
            paysEmission: "012",
            entiteEmettrice: "APC Alger",
            dateExpiration: "2030-12-31",
            nif: "123456789012",
            cleIntermediaire:"",
            cleOnomastique:""
        };
         
         PersonPhysic.presume=false;
        PersonPhysic.nationalite=true;
        console.log(PersonPhysic)
        const response = await axios.post(baseURL, PersonPhysic);
        return response.data;
    },
    getPersonPhysic: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updatePersonPhysic: async (id, PersonPhysic) => {
        console.log(id)
        console.log(PersonPhysic)
        const response = await axios.put(`${baseURL}/${id}`, PersonPhysic);
        return response.data;
    },
    deletePersonPhysic: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default PersonPhysicService;
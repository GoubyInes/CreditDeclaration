// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Commune';
const CommuneService = {
    getCommunes: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createCommune: async (commune) => {
        console.log(commune);
        const response = await axios.post(baseURL, commune);
        return response.data;
    },
    getCommune: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateCommune: async (id, domaine, commune) => {
        console.log(domaine);
        console.log(commune);
        const response = await axios.put(`${baseURL}/${id}/${domaine}`, commune);
        return response.data;
    },
    deleteCommune: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}/${domaine}`);
        return response.data;
    }
    
};
export default CommuneService;
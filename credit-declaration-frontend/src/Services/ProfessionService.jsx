// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Profession';
const ProfessionService = {
    getProfessions: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createProfession: async (Profession) => {
        const response = await axios.post(baseURL, Profession);
        return response.data;
    },
    getProfession: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateProfession: async (id, Profession) => {
        const response = await axios.put(`${baseURL}/${id}`, Profession);
        return response.data;
    },
    deleteProfession: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default ProfessionService;
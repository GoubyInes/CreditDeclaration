// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/SituationCredit';
const SituationService = {
    getSituations: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createSituation: async (Situation) => {
        const response = await axios.post(baseURL, Situation);
        return response.data;
    },
    getSituation: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateSituation: async (id, Situation) => {
        const response = await axios.put(`${baseURL}/${id}`, Situation);
        return response.data;
    },
    deleteSituation: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default SituationService;
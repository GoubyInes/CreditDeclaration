// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Monnaie';
const ChangeService = {
    getChanges: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createChange: async (Change) => {
        const response = await axios.post(baseURL, Change);
        return response.data;
    },
    getChange: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateChange: async (id, Change) => {
        console.log(Change)
         console.log(id)
        const response = await axios.put(`${baseURL}/${id}`, Change);
        return response.data;
    },
    deleteChange: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default ChangeService;
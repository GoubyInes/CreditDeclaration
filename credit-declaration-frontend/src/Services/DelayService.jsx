// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/ClasseRetard';
const DelayService = {
    getDelays: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createDelay: async (Delay) => {
        const response = await axios.post(baseURL, Delay);
        return response.data;
    },
    getDelay: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateDelay: async (id, Delay) => {
        const response = await axios.put(`${baseURL}/${id}`, Delay);
        return response.data;
    },
    deleteDelay: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default DelayService;
// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Wilaya';
const WilayaService = {
    getWilayas: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createWilaya: async (Wilaya) => {
        const response = await axios.post(baseURL, Wilaya);
        return response.data;
    },
    getWilaya: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateWilaya: async (id, Wilaya) => {
        const response = await axios.put(`${baseURL}/${id}`, Wilaya);
        return response.data;
    },
    deleteWilaya: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default WilayaService;
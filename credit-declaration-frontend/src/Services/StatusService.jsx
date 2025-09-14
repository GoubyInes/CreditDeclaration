// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/EtatCivil';
const StatusService = {
    getStatus: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createStatus: async (Status) => {
        const response = await axios.post(baseURL, Status);
        return response.data;
    },
    getStatu: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateStatus: async (id, Status) => {
        const response = await axios.put(`${baseURL}/${id}`, Status);
        return response.data;
    },
    deleteStatus: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default StatusService;
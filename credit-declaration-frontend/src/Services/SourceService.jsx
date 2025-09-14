// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/SourceInformation';
const SourceService = {
    getSources: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createSource: async (Source) => {
        const response = await axios.post(baseURL, Source);
        return response.data;
    },
    getSource: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateSource: async (id, Source) => {
        const response = await axios.put(`${baseURL}/${id}`, Source);
        return response.data;
    },
    deleteSource: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default SourceService;
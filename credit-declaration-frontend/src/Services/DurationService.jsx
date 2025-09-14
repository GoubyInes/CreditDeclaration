// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Duree';
const DurationService = {
    getDurations: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createDuration: async (Duration) => {
        const response = await axios.post(baseURL, Duration);
        return response.data;
    },
    getDuration: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateDuration: async (id, Duration) => {
        const response = await axios.put(`${baseURL}/${id}`, Duration);
        return response.data;
    },
    deleteDuration: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default DurationService;
// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/NiveauResponsabilite';
const LevelService = {
    getLevels: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createLevel: async (Level) => {
        const response = await axios.post(baseURL, Level);
        return response.data;
    },
    getLevel: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateLevel: async (id, Level) => {
        const response = await axios.put(`${baseURL}/${id}`, Level);
        return response.data;
    },
    deleteLevel: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default LevelService;
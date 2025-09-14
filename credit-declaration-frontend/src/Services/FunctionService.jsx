// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/FonctionDirigeant';
const FunctionService = {
    getFunctions: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createFunction: async (Function) => {
        const response = await axios.post(baseURL, Function);
        return response.data;
    },
    getFunction: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateFunction: async (id, Function) => {
        const response = await axios.put(`${baseURL}/${id}`, Function);
        return response.data;
    },
    deleteFunction: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default FunctionService;
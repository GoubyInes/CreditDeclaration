// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/TypePersonne';
const PersonTypeService = {
    getPersonTypes: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createPersonType: async (PersonType) => {
        const response = await axios.post(baseURL, PersonType);
        return response.data;
    },
    getPersonType: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updatePersonType: async (id, PersonType) => {
        const response = await axios.put(`${baseURL}/${id}`, PersonType);
        return response.data;
    },
    deletePersonType: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default PersonTypeService;
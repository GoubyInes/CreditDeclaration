// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/TypeCredit';
const CreditTypeService = {
    getCreditTypes: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createCreditType: async (CreditType) => {
        const response = await axios.post(baseURL, CreditType);
        return response.data;
    },
    getCreditType: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateCreditType: async (id, CreditType) => {
        const response = await axios.put(`${baseURL}/${id}`, CreditType);
        return response.data;
    },
    deleteCreditType: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default CreditTypeService;
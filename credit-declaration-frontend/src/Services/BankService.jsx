// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Banque';
const BankService = {
    getBanks: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createBank: async (bank) => {
        const response = await axios.post(baseURL, bank);
        return response.data;
    },
    getBank: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateBank: async (id, bank) => {
        const response = await axios.put(`${baseURL}/${id}`, bank);
        return response.data;
    },
    deleteBank: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default BankService;
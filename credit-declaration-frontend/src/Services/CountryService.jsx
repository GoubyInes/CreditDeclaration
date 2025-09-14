// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Pays';
const CountryService = {
    getCountrys: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createCountry: async (Country) => {
        const response = await axios.post(baseURL, Country);
        return response.data;
    },
    getCountry: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateCountry: async (id, Country) => {
        const response = await axios.put(`${baseURL}/${id}`, Country);
        return response.data;
    },
    deleteCountry: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default CountryService;
// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/TypeGarantie';
const CollateralService = {
    getCollateralTypes: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createCollateralType: async (Collateral) => {
        const response = await axios.post(baseURL, Collateral);
        return response.data;
    },
    getCollateralType: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateCollateralType: async (id, Collateral) => {
        const response = await axios.put(`${baseURL}/${id}`, Collateral);
        return response.data;
    },
    deleteCollateralType: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default CollateralService;
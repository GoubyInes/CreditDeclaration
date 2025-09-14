// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/TypeDocument';
const DocTypeService = {
    getDocTypes: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createDocType: async (DocType) => {
        const response = await axios.post(baseURL, DocType);
        return response.data;
    },
    getDocType: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateDocType: async (id, DocType) => {
        const response = await axios.put(`${baseURL}/${id}`, DocType);
        return response.data;
    },
    deleteDocType: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default DocTypeService;
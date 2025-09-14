// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/FormeJuridique';
const FormService = {
    getForms: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createForm: async (Form) => {
        const response = await axios.post(baseURL, Form);
        return response.data;
    },
    getForm: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    updateForm: async (id, Form) => {
        const response = await axios.put(`${baseURL}/${id}`, Form);
        return response.data;
    },
    deleteForm: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    }
    
};
export default FormService;
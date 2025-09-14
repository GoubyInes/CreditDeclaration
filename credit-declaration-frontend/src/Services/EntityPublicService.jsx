// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/EntitePublique';
const EntityPublicService = {
    getEntities: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createEntity: async (Entity) => {
        const response = await axios.post(baseURL, Entity);
        return response.data;
    },
    getEntity: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    deleteEntity: async (id) => {
        console.log(id)
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    },
    updateEntity: async (id, Entity) => {
        const response = await axios.put(`${baseURL}/${id}`, Entity);
        return response.data;
    }
};
export default EntityPublicService;
// src/services/ClientTypeService.js
import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL+'/api/Activite';
const ActivityService = {
    getActivities: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    createActivity: async (activity) => {
        const response = await axios.post(baseURL, activity);
        return response.data;
    },
    getActivity: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    deleteActivity: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        return response.data;
    },
    updateActivity: async (id, activity) => {
        const response = await axios.put(`${baseURL}/${id}`, activity);
        return response.data;
    }
};
export default ActivityService;
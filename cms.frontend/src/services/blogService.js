import axiosClient from "../api/axiosClient";

const blogService = {

    getBlogCategories: async () => {
        const url = "/Categories";
        return await axiosClient.get(url);
    },

    getAllPosts: async () => {
        const url = "/Posts";
        return await axiosClient.get(url);
    }
};

export default blogService;
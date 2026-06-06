import axiosClient from '../api/axiosClient';

const productService = {
    getAllProducts: () => {
        return axiosClient.get('/ProductsController1'); // 
    }
};

export default productService;
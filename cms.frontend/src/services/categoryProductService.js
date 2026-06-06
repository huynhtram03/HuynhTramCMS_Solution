/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 06-06-2026
 * Mô tả : Thực thể categoryProductService chứa các phương thức liên quan đến danh mục sản phẩm, kết nối với Backend thông qua axiosClient để lấy dữ liệu từ API.
 */

import axiosClient from '../api/axiosClient';

const categoryProductService = {
    /**
     * Hàm lấy toàn bộ danh mục SẢN PHẨM từ Backend
     * Endpoint này kết nối tới CategoryProductController trong ASP.NET Core
     */
    getAllCategoryProducts: () => {
        // Đường dẫn định tuyến khớp chính xác với cấu trúc định tuyến [Route("api/[controller]")] của Backend
        const url = '/CategoriesProduct';
        return axiosClient.get(url);
    }
};

export default categoryProductService;


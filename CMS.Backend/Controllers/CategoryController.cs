/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể danh mục trong hệ thống CMS, bao gồm các thuộc tính như Id, Name và Description. Danh mục được sử dụng để phân loại bài viết và có thể có nhiều bài viết liên quan đến một danh mục.
 */

using Microsoft.AspNetCore.Mvc;
using CMS.Data.Entities; // Kết nối tới lớp dữ liệu bạn vừa tạo

public class CategoryController : Controller
{
    // GET: /Category/
    public IActionResult Index()
    {
        // Tạo danh sách dữ liệu mẫu trực tiếp trong code
        var list = new List<Category> {
            new Category { Id = 1, Name = "Tin Công Nghệ", Description = "Review Laptop, AI" },
            new Category { Id = 2, Name = "Giáo Dục", Description = "Thông tin tuyển sinh" }
        };
        return View(list); // Gửi danh sách này sang giao diện
    }
}

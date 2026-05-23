/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể danh mục trong hệ thống CMS, bao gồm các thuộc tính như Id, Name và Description. Danh mục được sử dụng để phân loại bài viết và có thể có nhiều bài viết liên quan đến một danh mục.
 */

using Microsoft.EntityFrameworkCore;
using CMS.Data;

using Microsoft.AspNetCore.Mvc;
using CMS.Data.Entities; // Kết nối tới lớp dữ liệu bạn vừa tạo

//public class CategoryController : Controller
//{
//    // GET: /Category/
//    public IActionResult Index()
//    {
//        // Tạo danh sách dữ liệu mẫu trực tiếp trong code
//        var list = new List<Category> {
//            new Category { Id = 1, Name = "Tin Công Nghệ", Description = "Review Laptop, AI" },
//            new Category { Id = 2, Name = "Giáo Dục", Description = "Thông tin tuyển sinh" }
//        };
//        return View(list); // Gửi danh sách này sang giao diện
//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // =========================================
        // Constructor Injection
        // =========================================
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================
        // INDEX - DANH SÁCH DANH MỤC
        // =========================================
        public IActionResult Index()
        {
            var data = _context.Categories
                               .AsNoTracking()
                               .ToList();

            return View(data);
        }

        // =========================================
        // CREATE - GET
        // =========================================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================================
        // CREATE - POST
        // =========================================
        [HttpPost]
        public IActionResult Create(Category model)
        {
            _context.Categories.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================================
        // EDIT - GET (LOAD DATA LÊN FORM)
        // =========================================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // =========================================
        // EDIT - POST (CẬP NHẬT DỮ LIỆU)
        // =========================================
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _context.Categories.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================================
        // DELETE
        // =========================================
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
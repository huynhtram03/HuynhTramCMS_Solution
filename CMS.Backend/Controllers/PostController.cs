/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể bài viết trong hệ thống CMS, bao gồm các thuộc tính như Id, Title, Content, ImageUrl và CreatedDate. Bài viết là nội dung chính của hệ thống và có thể liên kết với một hoặc nhiều danh mục để phân loại. Bài viết cũng có thể được hiển thị trên trang chủ hoặc trong các danh mục cụ thể tùy theo yêu cầu của người dùng.
 */

//using Microsoft.AspNetCore.Mvc;
//using CMS.Data.Entities; // Quan trọng: Phải có dòng này để dùng lớp Post

//namespace CMS.Backend.Controllers
//{
//    // Bài viết
//    public class PostController : Controller
//    {
//        // Hàm Index: Hiển thị danh sách bài viết mẫu
//        public IActionResult Index()
//        {
//            // 1. Tạo dữ liệu giả (Mock Data) cho Bài viết
//            var posts = new List<Post>
//            {
//                new Post
//                {
//                    Id = 1,
//                    Title = "Lộ trình học ASP.NET Core cho người mới",
//                    Content = "Nội dung bài viết về lộ trình học .NET...",
//                    ImageUrl = "https://via.placeholder.com/150",
//                    CreatedDate = DateTime.Now
//                },
//                new Post
//                {
//                    Id = 2,
//                    Title = "ReactJS và WebAPI: Xu hướng Fullstack 2026",
//                    Content = "Nội dung bài viết về sự kết hợp React và API...",
//                    ImageUrl = "https://via.placeholder.com/150",
//                    CreatedDate = DateTime.Now.AddDays(-1)
//                },
//                new Post
//                {
//                    Id = 3,
//                    Title = "Hướng dẫn cài đặt môi trường Visual Studio",
//                    Content = "Các bước cài đặt công cụ cần thiết cho lập trình viên...",
//                    ImageUrl = "https://via.placeholder.com/150",
//                    CreatedDate = DateTime.Now.AddDays(-2)
//                }
//            };

//            // 2. Gửi danh sách dữ liệu sang View
//            return View(posts);
//        }

//        // Hàm Details: Hiển thị chi tiết một bài viết (Bổ sung  khá giỏi)
//        public IActionResult Details(int id)
//        {
//            // Giả lập tìm bài viết trong Database bằng Id
//            // Trong thực tế tuần sau sẽ là: _context.Posts.Find(id);
//            var post = new Post
//            {
//                Id = id,
//                Title = "Nội dung chi tiết bài viết số " + id,
//                Content = "Đây là nội dung đầy đủ của bài viết mà bạn vừa click vào. Ở đây  có thể viết dài hơn để thấy sự khác biệt với trang danh sách.",
//                ImageUrl = "https://via.placeholder.com/600x300", // Ảnh to hơn
//                CreatedDate = DateTime.Now
//            };

//            if (post == null) return NotFound();

//            return View(post);
//        }
//    }
//}
//
//using CMS.Backend.Data;


//using CMS.Backend.Models;
//using CMS.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace CMS.Backend.Controllers
//{
//    public class PostController : Controller
//    {
//        // Khai báo biến context
//        private readonly ApplicationDbContext _context;

//        // Constructor Injection
//        public PostController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Action Index
//        public IActionResult Index()
//        {
//            // Lấy tất cả bài viết từ database
//            var posts = _context.Posts.ToList();

//            // Trả dữ liệu sang View
//            return View(posts);
//        }
//    }
//}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//using CMS.Data;
//using CMS.Data.Entities;

//namespace CMS.Backend.Controllers
//{
//    public class PostController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        // Constructor Injection
//        public PostController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // =========================================
//        // DANH SÁCH BÀI VIẾT
//        // =========================================
//        public IActionResult Index(int? id)
//        {
//            // Lấy bài viết kèm theo thông tin Danh mục
//            var query = _context.Posts
//                                .Include(p => p.Category)
//                                .AsNoTracking()
//                                .AsQueryable();

//            // Nếu có CategoryId thì lọc theo danh mục
//            if (id.HasValue)
//            {
//                query = query.Where(p => p.CategoryId == id.Value);
//            }

//            // Sắp xếp bài viết mới nhất
//            var posts = query
//                        .OrderByDescending(p => p.CreatedDate)
//                        .ToList();

//            // Trả dữ liệu ra View
//            return View(posts);
//        }

//        // =========================================
//        // CHI TIẾT BÀI VIẾT
//        // =========================================

//        // GET: Post/Details/5
//        public IActionResult Details(int id)
//        {
//            // 1. Truy vấn bài viết theo ID
//            // Sử dụng .Include(p => p.Category) để lấy kèm thông tin Danh mục (Join bảng)
//            var post = _context.Posts
//                .Include(p => p.Category)
//                .FirstOrDefault(p => p.Id == id);

//            // 2. Kiểm tra nếu không tìm thấy bài viết (tránh lỗi màn hình trắng)
//            if (post == null)
//            {
//                return NotFound(); // Trả về trang lỗi 404
//            }

//            // 3. Truyền dữ liệu sang View
//            return View(post);
//        }
//    }
//}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//using CMS.Data;
//using CMS.Data.Entities;

//namespace CMS.Backend.Controllers
//{
//    public class PostController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        // Constructor Injection
//        public PostController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // =========================================
//        // DANH SÁCH BÀI VIẾT
//        // =========================================
//        public IActionResult Index(int? id)
//        {
//            // Lấy bài viết kèm theo thông tin Danh mục
//            var query = _context.Posts
//                                .Include(p => p.Category)
//                                .AsNoTracking()
//                                .AsQueryable();

//            // Nếu có CategoryId thì lọc theo danh mục
//            if (id.HasValue)
//            {
//                query = query.Where(p => p.CategoryId == id.Value);
//            }

//            // Sắp xếp bài viết mới nhất
//            var posts = query
//                        .OrderByDescending(p => p.CreatedDate)
//                        .ToList();

//            // Trả dữ liệu ra View
//            return View(posts);
//        }

//        // =========================================
//        // CHI TIẾT BÀI VIẾT
//        // =========================================

//        // GET: Post/Details/5
//        public IActionResult Details(int id)
//        {
//            // 1. Truy vấn bài viết theo ID
//            // Sử dụng .Include(p => p.Category) để lấy kèm thông tin Danh mục
//            var post = _context.Posts
//                .Include(p => p.Category)
//                .FirstOrDefault(p => p.Id == id);

//            // 2. Kiểm tra nếu không tìm thấy bài viết
//            if (post == null)
//            {
//                return NotFound();
//            }

//            // 3. Truyền dữ liệu sang View
//            return View(post);
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using CMS.Data;
using CMS.Data.Entities;
using System.Linq;

namespace CMS.Backend.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index(int? id)
        {
            var query = _context.Posts
                                .Include(p => p.Category)
                                .AsNoTracking()
                                .AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(p => p.CategoryId == id.Value);
            }

            var posts = query
                        .OrderByDescending(p => p.CreatedDate)
                        .ToList();

            return View(posts);
        }

        // =========================
        // CHI TIẾT
        // =========================
        public IActionResult Details(int id)
        {
            var post = _context.Posts
                               .Include(p => p.Category)
                               .FirstOrDefault(p => p.Id == id);

            if (post == null) return NotFound();

            return View(post);
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_context.CategoryProducts, "Id", "Name");
            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post model, IFormFile uploadImage)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryList = new SelectList(_context.CategoryProducts, "Id", "Name");
                return View(model);
            }

            // Upload ảnh
            if (uploadImage != null && uploadImage.Length > 0)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + Path.GetExtension(uploadImage.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadImage.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }

            model.CreatedDate = DateTime.Now;

            _context.Posts.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: Hiển thị form kèm dữ liệu cũ
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();

            // Chuẩn bị lại danh sách danh mục để người dùng có thể đổi chuyên mục
            ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Thực hiện cập nhật
        [HttpPost]
        public IActionResult Edit(Post model, IFormFile uploadImage)
        {
            // Bước 1: Kiểm tra xem người dùng có chọn file ảnh mới không
            if (uploadImage != null && uploadImage.Length > 0)
            {
                // Thực hiện quy trình upload giống như trang Create
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadImage.CopyTo(stream);
                }

                // Cập nhật đường dẫn ảnh mới vào model
                model.ImageUrl = "/uploads/" + fileName;
            }
            else
            {
                // Bước quan trọng: Nếu không upload ảnh mới, chúng ta phải giữ lại ảnh cũ
                // Chúng ta cần lấy lại giá trị ImageUrl từ Database để tránh bị ghi đè thành rỗng
                var oldPost = _context.Posts.AsNoTracking().FirstOrDefault(p => p.Id == model.Id);
                if (oldPost != null && string.IsNullOrEmpty(model.ImageUrl))
                {
                    model.ImageUrl = oldPost.ImageUrl;
                }
            }
            _context.Posts.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // =========================
        // DELETE (GET - HIỂN THỊ CONFIRM)
        // =========================
        public IActionResult Delete(int id)
        {
            var post = _context.Posts
                               .Include(p => p.Category)
                               .FirstOrDefault(p => p.Id == id);

            if (post == null) return NotFound();

            return View(post);
        }

        // =========================
        // DELETE (POST - XÓA THẬT)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.Find(id);

            if (post != null)
            {
                // 🔥 XÓA FILE ẢNH (nếu có)
                if (!string.IsNullOrEmpty(post.ImageUrl))
                {
                    var filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        post.ImageUrl.TrimStart('/')
                    );

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


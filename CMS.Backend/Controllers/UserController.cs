/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể nguời dùng trong hệ thống CMS, bao gồm các thuộc tính như Id, Username, PasswordHash, FullName và Role (quản trị viên hoặc biên tập viên).
 */

//using Microsoft.AspNetCore.Mvc;
//using CMS.Data.Entities; // Phải có dòng này để dùng lớp User

//namespace CMS.Backend.Controllers
//{
//    public class UserController : Controller
//    {
//        // Hàm Index: Hiển thị danh sách thành viên quản trị
//        public IActionResult Index()
//        {
//            // 1. Tạo danh sách Người dùng giả (Mock Data)
//            var users = new List<User>
//            {
//                new User
//                {
//                    Id = 1,
//                    Username = "admin_thai",
//                    FullName = "Nguyễn Cao Thái",
//                    Role = "Administrator"
//                },
//                new User
//                {
//                    Id = 2,
//                    Username = "editor_01",
//                    FullName = "Trần Văn Biên Tập",
//                    Role = "Editor"
//                },
//                new User
//                {
//                    Id = 3,
//                    Username = "author_minh",
//                    FullName = "Lê Quang Minh",
//                    Role = "Author"
//                }
//            };

//            // 2. Trả về View kèm theo danh sách người dùng
//            return View(users);
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
//    public class UserController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        // Inject DbContext
//        public UserController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // =========================
//        // DANH SÁCH USER (REAL DATA)
//        // =========================
//        public IActionResult Index()
//        {
//            var users = _context.Users
//                                .AsNoTracking()
//                                .ToList();

//            return View(users);
//        }
//    }
//}







using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index()
        {
            var users = _context.Users
                                .AsNoTracking()
                                .ToList();

            return View(users);
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User model, string Password)
        {
            model.Username = model.Username?.Trim();

            // Check username trùng
            var exists = _context.Users.Any(u => u.Username == model.Username);
            if (exists)
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại!");
            }

            // Check password
            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "Vui lòng nhập mật khẩu!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.PasswordHash = Password;

            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // EDIT (GET)
        // =========================
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User model, string NewPassword)
        {
            if (id != model.Id) return NotFound();

            model.Username = model.Username?.Trim();

            var oldUser = _context.Users
                                  .AsNoTracking()
                                  .FirstOrDefault(u => u.Id == id);

            if (oldUser == null) return NotFound();

            // Check username trùng
            var exists = _context.Users.Any(u => u.Username == model.Username && u.Id != id);
            if (exists)
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Password
            if (!string.IsNullOrEmpty(NewPassword))
            {
                model.PasswordHash = NewPassword;
            }
            else
            {
                model.PasswordHash = oldUser.PasswordHash;
            }

            _context.Users.Update(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // DELETE (GET)
        // =========================
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // =========================
        // DELETE (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
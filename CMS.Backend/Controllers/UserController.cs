/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể nguời dùng trong hệ thống CMS, bao gồm các thuộc tính như Id, Username, PasswordHash, FullName và Role (quản trị viên hoặc biên tập viên).
 */

using Microsoft.AspNetCore.Mvc;
using CMS.Data.Entities; // Phải có dòng này để dùng lớp User

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        // Hàm Index: Hiển thị danh sách thành viên quản trị
        public IActionResult Index()
        {
            // 1. Tạo danh sách Người dùng giả (Mock Data)
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin_thai",
                    FullName = "Nguyễn Cao Thái",
                    Role = "Administrator"
                },
                new User
                {
                    Id = 2,
                    Username = "editor_01",
                    FullName = "Trần Văn Biên Tập",
                    Role = "Editor"
                },
                new User
                {
                    Id = 3,
                    Username = "author_minh",
                    FullName = "Lê Quang Minh",
                    Role = "Author"
                }
            };

            // 2. Trả về View kèm theo danh sách người dùng
            return View(users);
        }
    }
}

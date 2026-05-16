/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể người dùng trong hệ thống CMS, bao gồm các thuộc tính như Id, Username, PasswordHash, FullName và Role (quản trị viên hoặc biên tập viên).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    // Lớp User đại diện cho một người dùng trong hệ thống CMS, bao gồm các thuộc tính như Id, Username, PasswordHash, FullName và Role (quản trị viên hoặc biên tập viên).
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } // Tên đăng nhập của người dùng
        public string PasswordHash { get; set; } // Mật khẩu đã được băm để bảo mật
        public string FullName { get; set; } // Họ và tên đầy đủ của người dùng
        public string Role { get; set; } // Quản trị viên hoặc Biên tập viên
    }
}

/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể danh mục bài viết trong hệ thống CMS, bao gồm các thuộc tính như Id, Name, Description và quan hệ với bài viết (Posts).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
   
    //Lớp Category đại diện cho một danh mục bài viết trong hệ thống CMS.
    public class Category
    {
        public int Id { get; set; } // Khóa chính
        public string Name { get; set; } // Tên danh mục (vd: Tin Giáo Dục)
        public string Description { get; set; } // Mô tả danh mục (vd: Chuyên mục tin tức về giáo dục)

        // Quan hệ: Một danh mục có nhiều bài viết
        public virtual ICollection<Post> Posts { get; set; }
    }
}

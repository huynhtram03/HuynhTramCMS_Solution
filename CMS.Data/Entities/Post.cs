/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể bai viết trong hệ thống CMS, bao gồm các thuộc tính như Id, Title, Content, Author và quan hệ với danh mục (Category) và bình luận (Comments).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    // Lớp Post đại diện cho một bài viết trong hệ thống CMS, bao gồm các thuộc tính như Id, Title, Content, Author và quan hệ với danh mục (Category) và bình luận (Comments).
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung chi tiết
        public string ImageUrl { get; set; } // Hình ảnh đại diện
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Ngày tạo bài viết

        // Khóa ngoại liên kết tới Category
        public int CategoryId { get; set; } // Id của danh mục mà bài viết thuộc về
        public virtual Category Category { get; set; } //   Quan hệ: Một bài viết thuộc về một danh mục
    }
}

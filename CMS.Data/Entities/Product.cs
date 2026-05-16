/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể sản phẩm trong hệ thống CMS, bao gồm các thuộc tính như Id, Name, Description, Price và quan hệ với danh mục sản phẩm (CategoryProduct).
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    // Lớp Product đại diện cho một sản phẩm trong hệ thống CMS, bao gồm các thuộc tính như Id, Name, Description, Price và quan hệ với danh mục sản phẩm (CategoryProduct).
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")] // Ràng buộc bắt buộc nhập tên sản phẩm
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")] // Định nghĩa kiểu dữ liệu decimal với độ chính xác 18 và số thập phân 2 cho giá sản phẩm
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        // Khóa ngoại nối tới CategoryProduct
        public int CategoryProductId { get; set; }

        [ForeignKey("CategoryProductId")]
        public virtual CategoryProduct? CategoryProduct { get; set; } // Quan hệ: Một sản phẩm thuộc về một danh mục sản phẩm
    }
}

/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể danh mục sản phẩm trong hệ thống CMS, bao gồm các thuộc tính như Id, Name, Description và quan hệ với sản phẩm (Products).
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    // Lớp CategoryProduct đại diện cho một danh mục sản phẩm trong hệ thống CMS, bao gồm các thuộc tính như Id, Name, Description và quan hệ với sản phẩm (Products).
    public class CategoryProduct
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Quan hệ: Một danh mục có nhiều sản phẩm
        public virtual ICollection<Product>? Products { get; set; } // Danh sách sản phẩm thuộc danh mục này
    }
}

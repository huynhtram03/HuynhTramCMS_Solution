/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể đơn hàng trong hệ thống CMS, bao gồm các thuộc tính như Id, OrderDate, CustomerId, Status, Notes và quan hệ với khách hàng (Customer) và chi tiết đơn hàng (OrderDetails).
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
    // Lớp Order đại diện cho một đơn hàng trong hệ thống CMS, bao gồm các thuộc tính như Id, OrderDate, CustomerId, Status, Notes và quan hệ với khách hàng (Customer) và chi tiết đơn hàng (OrderDetails).
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }

        public int Status { get; set; } // 0: Chờ duyệt, 1: Đang giao, 2: Đã xong

        public string? Notes { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

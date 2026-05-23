/*
 * Sinh viên : Nguyễn Ngọc Huỳnh Trâm
 * Mã sv: 2123110120
 * Lớp :CCQ2311D
 * Ngày tạo: 16-05-2026
 * Mô tả : Thực thể ApplicationDbContext trong hệ thống CMS, đây là lớp đại diện cho cơ sở dữ liệu của ứng dụng. Nó sẽ chứa các DbSet cho các thực thể như User, Category, Article và Comment, cho phép chúng ta tương tác với cơ sở dữ liệu thông qua Entity Framework Core.
 */

using Microsoft.EntityFrameworkCore;
using CMS.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet = bảng trong database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; } // FIX tên
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // (Optional) Cấu hình thêm bằng Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ví dụ: đặt tên bảng (nếu cần)
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
    }
}
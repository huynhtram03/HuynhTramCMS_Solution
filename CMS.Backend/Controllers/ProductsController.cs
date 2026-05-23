using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;

namespace CMS.Backend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // DANH SÁCH PRODUCT
        // =========================
        public IActionResult Index()
        {
            var products = _context.Products
                                   .Include(p => p.CategoryProduct) // 🔥 Lấy tên danh mục
                                   .AsNoTracking()
                                   .ToList();

            return View(products);
        }
    }
}
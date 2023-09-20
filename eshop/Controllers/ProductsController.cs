using eshop.Data;
using Microsoft.AspNetCore.Mvc;
using eshop.Models;
namespace eshop.Controllers

{
    public class ProductsController : Controller
    {

        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Products.ToList();
            
            return View(data);
        }
    }

}
using eshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class CustomersController : Controller
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var data = _context.Customers.ToList();
        return View(data);
    }
}
using eshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class OrdersController : Controller
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var data = _context.Orders.ToList();
        return View(data);
    }
}
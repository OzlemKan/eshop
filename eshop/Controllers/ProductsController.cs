using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class CustomersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
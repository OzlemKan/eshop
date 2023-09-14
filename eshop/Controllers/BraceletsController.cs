using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class BraceletsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
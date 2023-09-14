using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class EarringsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using eshop.Data;
using eshop.Data.Services;
using eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomersService _service;

    public CustomersController(ICustomersService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAll();
        return View(data);
    }

    public  IActionResult Register()
    {
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> Register([Bind("FirstName,LastName,Email,Address,PhoneNumber,Birthday")] Customers customer)
    {
        if (ModelState.IsValid)
        {
            _service.Add(customer);
            return RedirectToAction("Index");
            
            
        }
        return View(customer);

        
    }
}
using eshop.Data;
using eshop.Data.Services;
using eshop.Models;
using eshop.Views.customers;
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
        var data = await _service.GetAllAsync();
        return View(data);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        [Bind("FirstName,LastName,Email,Address,PhoneNumber,Birthday")] Customers customer)
    {
        if (ModelState.IsValid)
        {
            await _service.AddAsync(customer);
            return RedirectToAction("Index");
        }

        return View(customer);
    }

    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customerDetails = await _service.GetByIdAsync(id);

        if (customerDetails == null) return View("Empty");
        return View(customerDetails);
    }
}
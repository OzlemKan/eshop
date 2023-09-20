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

        return View(customerDetails);
    }
    //EDIT CUSTOMER
    public async Task <IActionResult> EditCustomer(int id)
    
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        return View(customerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> EditCustomer(int id, [Bind("CustomerId, FirstName, LastName, Email, Address, PhoneNumber, Birthday")] Customers customer)
    {
        if (ModelState.IsValid)
        {
            // ModelState is valid, so attempt to update the customer
            var updatedCustomer = await _service.UpdateAsync(id, customer);

            if (updatedCustomer == null)
            {
                // Handle the case where the customer with the specified ID was not found
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        // ModelState is not valid, return the view with validation errors
        return View(customer);
    }

    
    
    
    //DELETE CUSTOMER
    
    public async Task <IActionResult> DeleteCustomer(int id)
    
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        return View(customerDetails);
    }

    [HttpPost, ActionName("DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomerConfirmed(int id)
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        
        await _service.DeleteAsync(id);
        return RedirectToAction("index");

        
    }
}
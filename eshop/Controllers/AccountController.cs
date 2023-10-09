using eshop.Data;
using eshop.Data.ViewModels;
using eshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eshop.Data.Services;
using eshop.Data.Static;
using Microsoft.AspNetCore.Authorization;

namespace eshop.Controllers;

public class AccountController : Controller
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppDbContext _context;
    private string? RegisterVM;
    private readonly IAccountService _service;

    public AccountController(IAccountService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
    {
        _service = service;
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }
    

    public async Task<IActionResult> Users()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }
    
    [AllowAnonymous]
    public IActionResult Login() => View(new LoginVM
    {
        Email = null,
        Password = null
    });

    
    [AllowAnonymous]

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid) return View(loginVM);

        var user = await _userManager.FindByEmailAsync(loginVM.Email);
        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Products");
                }

                TempData["Error"] = "Wrong credentials, please try again!";
                return View(loginVM);
            }
        }

        TempData["Error"] = "Wrong credentials, please try again!";
        return View(loginVM);

    }
    
    [AllowAnonymous]
    public IActionResult Register() => View( new RegisterVM
    {
        Password = null,
        ConfirmPassword = null
    });

    [HttpPost]

    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid) return View(registerVM);

        var user = await _userManager.FindByEmailAsync(registerVM.Email);
        if (user != null)
        {
            TempData["Error"] = "An account with this email address already exists!";
            return View(registerVM);
        }

        var newUser = new ApplicationUser()
        {
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            Email = registerVM.Email,
            Address = registerVM.Address,
            PhoneNumber = registerVM.PhoneNumber,
            Birthday = registerVM.Birthday,
            UserName = registerVM.FirstName
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

        if (!newUserResponse.Succeeded)
        {
            // Handle the case where user creation failed
            foreach (var error in newUserResponse.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // Return the registration view with error messages
            return View(registerVM);
        }
        return View("RegisterCompleted");
    }
    
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Products");
    }


    public async Task <IActionResult> DeleteCustomer(string id)
    
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        return View(customerDetails);
    }
    
    [HttpPost, ActionName("DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomerConfirmed(string id)
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        
        await _service.DeleteAsync(id);
        return RedirectToAction("Users");

        
    }

    public async Task <IActionResult> EditCustomer(string id)
    
    {
        var customerDetails = await _service.GetByIdAsync(id);
        if (customerDetails == null) return View("NotFound");
        return View(customerDetails);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditCustomer(string id, [Bind("Id, FirstName, LastName, Email, Address, PhoneNumber, Birthday")] ApplicationUser user)
    {
        if (ModelState.IsValid)
        {
            // ModelState is valid, so attempt to update the customer
            var updatedUser = await _service.UpdateAsync(id, user);

            if (updatedUser == null)
            {
                // Handle the case where the customer with the specified ID was not found
                return NotFound();
            }

            return RedirectToAction("Users");
        }

        // ModelState is not valid, return the view with validation errors
        return View(user);
    }

    public async Task<IActionResult> GetCustomerById(string id)
    {
        var customerDetails = await _service.GetByIdAsync(id);

        return View(customerDetails);
    }

    [AllowAnonymous]
    public IActionResult AccessDenied(string returnUrl)
    {
        return View();
    }
}
    
    


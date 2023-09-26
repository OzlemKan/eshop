using eshop.Data;
using eshop.Data.Cart;
using eshop.Data.Services;
using Microsoft.AspNetCore.Mvc;
using eshop.Models;
namespace eshop.Controllers;


public class OrdersController : Controller
{

    private readonly IProductService _productService;
    private readonly ShoppingCart _shoppingCart;

    public OrdersController(IProductService productService, ShoppingCart shoppingCart ) // we inject the shoppingcart in the ctor
    {
        _productService = productService;
        _shoppingCart = shoppingCart;
    }

    public IActionResult Index() // use this to get a list of all the shoppingCartItems
    {
        return View();
    }
    
}

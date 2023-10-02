using eshop.Data;
using eshop.Data.Cart;
using eshop.Data.Services;
using eshop.Data.ViewModels;
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

    public IActionResult ShoppingCart() 
    {
        var items = _shoppingCart.GetShoppingCartItems(null);  // use this to get a list of all the shoppingCartItems
        _shoppingCart.ShoppingCartItems = items;
        
 
        var response = new ShoppingCartVm(null)
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            
        };
        return View(response); 
    }

    public async Task<IActionResult> AddToShoppingCart(int id) // int id = item id
    {
        var item = await _productService.GetByIdAsync(id);

        _shoppingCart.AddItemToCart(item);

        return RedirectToAction(nameof(ShoppingCart));
    }
    
    public async Task<IActionResult> RemoveItemFromShoppingCart(int id) // int id = item id
    {
        var item = await _productService.GetByIdAsync(id);
        _shoppingCart.RemoveItemFromCard(item);
        return RedirectToAction(nameof(ShoppingCart));
    }
}

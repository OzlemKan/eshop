using eshop.Data;
using eshop.Data.Cart;
using eshop.Data.Services;
using eshop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using eshop.Models;
using Humanizer;

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

    public IActionResult ShoppingCart() // GET A LIST OF ALL THE SHOPPING CART ITEMS
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartVm()
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

        return RedirectToAction(nameof(Data.Cart.ShoppingCart));
    }
    
    public async Task<IActionResult> RemoveItemFromShoppingCart(int id) // int id = item id
    {
        var item = await _productService.GetByIdAsync(id);
        _shoppingCart.RemoveItemFromCard(item);
        return RedirectToAction(nameof(Index));
    }
}

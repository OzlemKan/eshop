


using eshop.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eshop.Data.ViewComponents;

public class ShoppingCartSummary:ViewComponent
{
    private readonly ShoppingCart _shoppingCart; // get the number of items in shopping cart

    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCartItems();

        return View(items.Count);
    }

}

// petit panier au dessus, pour le summary du panier
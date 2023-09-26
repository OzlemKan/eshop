using System.Collections;
using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Cart;

public class ShoppingCart // add and remove data from shopping cart, the shopping cart items get stored in the db
{
    public AppDbContext _context { get; set; } // injecter la db

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(AppDbContext context) //constructor
    {
        _context = context;
    }
    
//ADD   
    // add to the shopping cart

    public void AddItemToCart(Products products)
        // check if we already have the product in our shopping cart, if yes : increase the amount by 1
        // otherwise, add the new product to the shopping cart and set the amount to 1
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null) // check if shopping cart is empty
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Products = products,
                Amount = 1
            };
            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else // OTHERWISE, 
        {
            shoppingCartItem.Amount++;
        }


        _context.SaveChanges();

    }
// DELETE
    public void RomoveItemFromCard(Products products)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null) // check if shopping cart is empty
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        _context.SaveChanges();
        
    }
    
//UPDATE
// get all the shopping cart items 

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Include(n => n.Products).ToList());
    }
//  get the  shopping cart total 

    public decimal GetShoppingCartTotal()  => _context.ShoppingCartItems
        .Where(n => n.ShoppingCartId == ShoppingCartId)
        .Select(n => n.Products.ProductPrice * n.Amount)
        .Sum();
        
    }

// quand on fait n => n. cela veut dire : for each item
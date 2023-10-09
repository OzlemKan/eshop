
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
    

    // to get the session and to check  the service and check if we already have a service with that cart id, otherwise generate a new id and  set that id to new session
    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDbContext>();
        // ?? mean "if this is null"
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }
    
//ADD   
    // add to the shopping cart

    public void AddItemToCart(Products products)
    {
        // Check if we already have the product in our shopping cart
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(n => n.Products != null && n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            // If the product is not in the cart, create a new shoppingCartItem
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId, // Make sure ShoppingCartId is properly initialized
                Products = products,
                Amount = 1 // 1st item in the shopping cart, 1st product of that type
            };
            _context.ShoppingCartItems.Add(shoppingCartItem); // Add the shoppingCartItem to the database
        }
        else
        {
            shoppingCartItem.Amount++; // If the product is already in the cart, increase the amount by one
        }

        _context.SaveChanges();
    }

// DELETE
    public void RemoveItemFromCard(Products products)
    {
        var shoppingCartItem = _context.ShoppingCartItems // check if we have this product in the shopping bag
            .FirstOrDefault(n => n.Products != null && n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null) // check if shopping cart is empty, if we have a shopping cart in the db
        {
            if (shoppingCartItem.Amount > 1) 
            {
                shoppingCartItem.Amount--; // we increase by one
            }
            else // OTHERWISE mean that we have just 1 item, so we remove it 
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        _context.SaveChanges();
        
    }

// get all the shopping cart items 

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        
        return ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n =>n.Products).ToList();
          
    }
//  get the  shopping cart total 

    public double GetShoppingCartTotal()  => (double)_context.ShoppingCartItems
        .Where(n => n.ShoppingCartId == ShoppingCartId)
        .Select(n => n.Products!.ProductPrice * n.Amount)
        .Sum();
}

// quand on fait n => n. cela veut dire : for each item
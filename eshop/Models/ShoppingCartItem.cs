using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;

namespace eshop.Models;


public class ShoppingCartItem
{
    [Key]
    public int ShoppingCartItemId { get; set; }
    
    public Products Products { get; set; }

    public int Amount { get; set; }

    public string? ShoppingCartId { get; set; }  // clean up the db after the order is complete,
                                                 // all the order base data is going to be in the db
    
    
}
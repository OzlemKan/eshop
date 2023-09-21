using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Patterns;

namespace eshop.Models;

public class ShoppingCartItem
{
    [Key]
    public int ShoppingCartItemId { get; set; }

    public Products? Products { get; set; }

    public int Amount { get; set; }

    public string? ShoppingCartId { get; set; }
    
    
}
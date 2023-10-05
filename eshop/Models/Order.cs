using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace eshop.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; } // identify of a order

    public string? Email { get; set; } // for the order to be related to a user

    public string? UserId { get; set; }

    public List<OrderItem>? OrderItem { get; set; }
    
    [Required]
    public string? OrderName { get; set; }
        
    [Required]
    [DataType(DataType.Currency)]
    public decimal OrderPrice { get; set; }
    
    [Required]    
    public int OrderQuantity { get; set; }
    
    [Required]
    public string? OrderDelivery { get; set; }
} 
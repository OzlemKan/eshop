using System.ComponentModel.DataAnnotations;
using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Models;

public class Orders
{
    [Key]
    public int OrderId { get; set; }
    
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
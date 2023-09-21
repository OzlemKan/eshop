using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace eshop.Models;

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }

    public int Amount { get; set; }

    public double Price { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductsId")]

    public Products? Products { get; set; } // relira direct au model product
    
    public int OrdersId { get; set; }
    [ForeignKey("OrdersId")]

    public Orders? Orders { get; set; }
    
    
    
}
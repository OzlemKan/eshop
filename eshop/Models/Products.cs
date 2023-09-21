using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    
    public required string  ProductName { get; set; } 
    
    public required string ProductImage { get; set; }
    
    [Required]
    [DataType(DataType.Currency)]
    public decimal ProductPrice { get; set; }
    
    [Required]    
    public int ProductQuantity { get; set; }
    
    public required string ProductDescription { get; set; }
    
    public required string ProductDelivery { get; set; }

    public required string ProductCategory { get; set; }
}
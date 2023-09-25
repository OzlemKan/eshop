using System.ComponentModel.DataAnnotations;
using eshop.Data;

namespace eshop.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    
    [Display(Name = "Name")]
    public required string  ProductName { get; set; } 
    
    [Display(Name = "Picture")]
    public required string ProductImage { get; set; }
    
    [Display(Name = "Description")]
    public required string ProductDescription { get; set; }
    
    public required string ProductDelivery { get; set; }

    public required ProductCategory ProductCategory { get; set; }
    
    
    [Display(Name = "Price")]
    [Required]
    [DataType(DataType.Currency)]
    public decimal ProductPrice { get; set; }
    
    [Required]    
    public int ProductQuantity { get; set; }
}

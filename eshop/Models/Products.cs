using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using eshop.Data;

namespace eshop.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    
    [Display(Name = "Product Name")]
    public required string  ProductName { get; set; } 
    
    [Display(Name = "Product Image")]
    public required string ProductImage { get; set; }
        
    
    [Required]
    [DataType(DataType.Currency)]
    [Display(Name = "Product Price")]
    public decimal ProductPrice { get; set; }
    
    [Required]    
    [Display(Name = "Product Quantity")]
    public int ProductQuantity { get; set; }
    
    [Display(Name = "Product Description")]
    public required string ProductDescription { get; set; }
    
    [Display(Name = "Product Delivery")]
    public required string ProductDelivery { get; set; }
    
    [Display(Name = "Product Category")]
    public  ProductCategory ProductCategory { get; set; }
}
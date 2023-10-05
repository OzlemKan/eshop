using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using eshop.Data;

namespace eshop.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    
    [Display(Name = "Name")]
    public required string  ProductName { get; set; } 
    
    [Display(Name = "Image")]
    public required string ProductImage { get; set; }
        
    
    [Required]
    [DataType(DataType.Currency)]
    [Display(Name = "Price")]
    public double ProductPrice { get; set; }
    
    [Required]    
    [Display(Name = "Quantity")]
    public int ProductQuantity { get; set; }
    
    [Display(Name = "Description")]
    public required string ProductDescription { get; set; }
    
    [Display(Name = "Delivery")]
    public required string ProductDelivery { get; set; }
    
    [Display(Name = "Category")]
    public  ProductCategory ProductCategory { get; set; }
}
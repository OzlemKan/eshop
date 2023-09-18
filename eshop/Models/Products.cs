using System.ComponentModel.DataAnnotations;
using eshop.Data;
using eshop.Models;

namespace test_2.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    public string Product { get; set; }
        
    [Required]
    [DataType(DataType.Currency)]
    public decimal ProductPrice { get; set; }
    
    [Required]    
    public int ProductQuantity { get; set; }
    
    [Required]
    public string ProductDescription { get; set; }
    
    [Required]
    public string ProductDelivery { get; set; }
}
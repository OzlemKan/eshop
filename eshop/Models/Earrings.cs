using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public class Earrings
{
    [Key]
    public int    EarringId { get; set; }
    
    [Required]
    public string EarringName { get; set; }
    
    [Required]
    [DataType(DataType.Currency)]
    public decimal EarringPrice { get; set; }
    
    [Required] 
    public int EarringQuantity { get; set; }
    
    [Required]
    public string EarringDescription { get; set; }
    
    [Required]
    public string EarringDelivery { get; set; }
    
}



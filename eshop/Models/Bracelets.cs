using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public class Bracelets
{
    [Key]
    public int BraceletId { get; set; }
    
    [Required]
    public string BraceletName { get; set; }
    
    [Required]
    [DataType(DataType.Currency)]
    public decimal BraceletPrice { get; set; }
    
    [Required] 
    public int BraceletQuantity { get; set; }
    
    [Required]
    public string BraceletDescription { get; set; }
    
    [Required]
    public string BraceletDelivery { get; set; }
    
}


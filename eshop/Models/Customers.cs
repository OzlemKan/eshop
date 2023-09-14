using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public class Customers
{
    [Key]
    public int    CustomerId { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }
    
}

using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public class Customers
{
    [Key]
    public int    CustomerId { get; set; }
    
    
    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    
    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
    
    [Required]
    [Display(Name = "Address")]
    public string? Address { get; set; }
    
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Birthday")]
    public DateTime Birthday { get; set; }
    
}
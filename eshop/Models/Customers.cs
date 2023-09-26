using System.ComponentModel.DataAnnotations;

namespace eshop.Models;

public partial class Customers
{
    [Key]
    public int    CustomerId { get; set; }
    
    
    [Required (ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    
    [Required (ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
    [Required (ErrorMessage = "Email is required")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
    
    [Required (ErrorMessage = "Address is required")]
    [Display(Name = "Address")]
    public string? Address { get; set; }
    
    [Required (ErrorMessage = "Phone Number is required")]
    [Phone]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
    
    [Required (ErrorMessage = "Birthday is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Birthday")]
    public DateTime Birthday { get; set; }
    
}

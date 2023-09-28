using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Security;

namespace eshop.Data.ViewModels;

public class RegisterVM
{
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
    
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage =" Passwords do not match")]
    public required string ConfirmPassword { get; set; }
}
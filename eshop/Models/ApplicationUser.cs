using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eshop.Models;

public class ApplicationUser: IdentityUser
{
    
    [Required (ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    
    [Required (ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
    [Display (Name = "Address")]
    public string Address { get; set; }
    
    [Phone]
    [Display (Name = "Phone Number")]
    public new string PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }
}
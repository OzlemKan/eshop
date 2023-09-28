using System.ComponentModel.DataAnnotations;

namespace eshop.Data.ViewModels;

public class LoginVM
{
   [Display (Name = "Email")]
    public required string Email { get; set; }
    [Display (Name = "Password")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
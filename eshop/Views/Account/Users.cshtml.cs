using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eshop.Views.Account;

public class Users : PageModel
{
    public void OnGet()
    {
        
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
}
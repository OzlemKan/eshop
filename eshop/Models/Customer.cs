using System.Security.Principal;

namespace eshop.Models;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Adress { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Enum Phone { get; set; }
}
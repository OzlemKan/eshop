using eshop.Models;
using eshop.Views.Account;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;

    public AccountService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        var result = await _context.Users.ToListAsync();
        return result;
    }

    
    

    public async Task<ApplicationUser?> GetByIdAsync(string id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
        return result;
    }

    public Task AddAsync(Users users)
    {
        throw new NotImplementedException();
    }
    


    public async Task Add(ApplicationUser users)
    {
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();
    }

    public async Task<ApplicationUser> UpdateAsync(string id, ApplicationUser newUser)
    {
        // Find the existing customer by its unique identifier
        var existingUser = await _context.Users.FindAsync(id);

        if (existingUser == null)
        {
            // Handle the case where the customer with the specified ID doesn't exist
            return null;
        }

        // Update the properties of the existing customer with the new data
        existingUser.FirstName = newUser.FirstName;
        existingUser.LastName = newUser.LastName;
        existingUser.Email = newUser.Email;
        existingUser.Address = newUser.Address;
        existingUser.PhoneNumber = newUser.PhoneNumber;
        existingUser.Birthday = newUser.Birthday;

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the updated existing customer object
        return existingUser;
    }


    public async Task DeleteAsync(string id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
        _context.Users.Remove(result);
        await _context.SaveChangesAsync();
    }
}


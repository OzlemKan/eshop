using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public class CustomersService : ICustomersService
{
    private readonly AppDbContext _context;

    public CustomersService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Customers>> GetAllAsync()
    {
        var result = await _context.Customers.ToListAsync();
        return result;
    }

    public async Task<Customers> GetByIdAsync(int id)
    {
        var result = await _context.Customers.FirstOrDefaultAsync(n => n.CustomerId == id);
        return result;
    }

    public Task AddAsync(Customers customers)
    {
        throw new NotImplementedException();
    }
    

    public async Task Add(Customers customers)
    {
        await _context.Customers.AddAsync(customers);
        await _context.SaveChangesAsync();
    }

    public async Task<Customers> UpdateAsync(int id, Customers newCustomer)
    {
        // Find the existing customer by its unique identifier
        var existingCustomer = await _context.Customers.FindAsync(id);

        if (existingCustomer == null)
        {
            // Handle the case where the customer with the specified ID doesn't exist
            return null;
        }

        // Update the properties of the existing customer with the new data
        existingCustomer.FirstName = newCustomer.FirstName;
        existingCustomer.LastName = newCustomer.LastName;
        existingCustomer.Email = newCustomer.Email;
        existingCustomer.Address = newCustomer.Address;
        existingCustomer.PhoneNumber = newCustomer.PhoneNumber;
        existingCustomer.Birthday = newCustomer.Birthday;

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the updated existing customer object
        return existingCustomer;
    }


    public async Task DeleteAsync(int id)
    {
        var result = await _context.Customers.FirstOrDefaultAsync(n => n.CustomerId == id);
        _context.Customers.Remove(result);
        await _context.SaveChangesAsync();
    }
}


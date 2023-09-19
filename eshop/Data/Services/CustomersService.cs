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

    public Customers Update(int id, Customers newCustomers)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}


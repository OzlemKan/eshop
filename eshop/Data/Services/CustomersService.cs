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
    
    public async Task<IEnumerable<Customers>> GetAll()
    {
        var result = await _context.Customers.ToListAsync();
        return result;
    }

    public Customers GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Customers customers)
    {
        _context.Customers.Add(customers);
        _context.SaveChanges();
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


using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public interface ICustomersService
{
    Task<IEnumerable<Customers>> GetAllAsync();

    Task<Customers> GetByIdAsync(int id);

    Task AddAsync(Customers customers);
    
    Task <Customers> UpdateAsync(int id, Customers newCustomer);

    Task DeleteAsync(int id);

}
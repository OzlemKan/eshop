using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public interface ICustomersService
{
    Task<IEnumerable<Customers>> GetAll();

    Customers GetById(int id);

    void Add(Customers customers);
    
    Customers Update(int id, Customers newCustomers);

    void Delete(int id);

}
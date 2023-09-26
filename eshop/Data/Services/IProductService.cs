using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public interface IProductService
{
    Task<IEnumerable<Products>> GetAllAsync();

    Task<Products> GetByIdAsync(int id);

    Task AddAsync(Products products);
    
    Task <Products> UpdateAsync(int id, Products newProduct);

    Task DeleteAsync(int id);

   
   
}
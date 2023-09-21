using eshop.Models;


namespace eshop.Data.Services;

public interface IProductsService
{
    IEnumerable<Products> GetAll();

    Products GetById(int id);

    void Add(Products customers);
    
    Products Update(int id, Products newProducts);

    void Delete(int id);

}


using eshop.Models;


namespace eshop.Data.Services;

public interface IProductsService
{
    IEnumerable<Products> GetAll(); // get all the products from db

    Products GetById(int id); // method to return a single product

    void Add(Products customers); // method to add data to db, not to the user(void)
    
    Products Update(int productId, Products newProducts); // functionality to update data in the db

    void Delete(int productId); // delete method 

}


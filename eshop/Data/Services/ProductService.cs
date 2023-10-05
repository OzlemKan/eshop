using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Products>> GetAllAsync()
    {
        var result = await _context.Products.ToListAsync();
        return result;
    }

    public async Task<Products> GetByIdAsync(int id)
    {
        var result = await _context.Products.FirstOrDefaultAsync(n => Equals(n.ProductId, id));
        return result;
    }

   // comm


    public async Task AddAsync(Products products)
    {
        await _context.Products.AddAsync(products);
        await _context.SaveChangesAsync();
    }

    public async Task<Products> UpdateAsync(int id, Products newProduct)
    {
        // Find the existing product by its unique identifier
        var existingProduct = await _context.Products.FindAsync(id);

        if (existingProduct == null)
        {
            // Handle the case where the product with the specified ID doesn't exist
            return null;
        }

        // Update the properties of the existing product with the new data
        existingProduct.ProductName = newProduct.ProductName;
        existingProduct.ProductCategory = newProduct.ProductCategory;
        existingProduct.ProductDelivery = newProduct.ProductDelivery;
        existingProduct.ProductImage = newProduct.ProductImage;
        existingProduct.ProductPrice = newProduct.ProductPrice;
        existingProduct.ProductDescription = newProduct.ProductDescription;

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the updated existing product object
        return existingProduct;
    }


    public async Task DeleteAsync(int id)
    {
        var result = await _context.Products.FirstOrDefaultAsync(n => Equals(n.ProductId, id));
        _context.Products.Remove(result);
        await _context.SaveChangesAsync();
    }
}


using eshop.Data;
using eshop.Data.Services;
using eshop.Data.Static;
using Microsoft.AspNetCore.Mvc;
using eshop.Models;
using Microsoft.AspNetCore.Authorization;

namespace eshop.Controllers;

[Authorize (Roles = UserRoles.Admin)]
public class ProductsController : Controller
{
    
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allProducts = await _service.GetAllAsync();
            
        return View(allProducts);
    }
    

    public async Task <IActionResult> EditProduct(int id)
    
    {
        var productDetails = await _service.GetByIdAsync(id);
        if (productDetails == null) return View("NotFound");
        return View(productDetails);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditProduct(int id, [Bind("ProductName, ProductImage, ProductPrice, ProductDelivery, ProductDescription, ProductCategory")] Products product)
    {
        if (ModelState.IsValid)
        {
            // ModelState is valid, so attempt to update the product
            var updatedProduct = await _service.UpdateAsync(id, product);

            if (updatedProduct == null)
            {
                // Handle the case where the product with the specified ID was not found
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        // ModelState is not valid, return the view with validation errors
        return View(product);
    }

    //DELETE PRODUCT
    
    public async Task <IActionResult> DeleteProduct(int id)
    
    {
        var productDetails = await _service.GetByIdAsync(id);
        if (productDetails == null) return View("NotFound");
        return View(productDetails);
    }

    [HttpPost, ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteProductConfirmed(int id)
    {
        var productDetails = await _service.GetByIdAsync(id);
        if (productDetails == null) return View("NotFound");
        
        await _service.DeleteAsync(id);
        return RedirectToAction("index");

        
    }
//ADD A NEW PRODUCT
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(
        [Bind("ProductName, ProductImage, ProductPrice, ProductDelivery, ProductDescription, ProductCategory")] Products product)
    {
        if (ModelState.IsValid)
        {
            await _service.AddAsync(product);
            return RedirectToAction("Index");
        }

        return View(product);
    }

    [AllowAnonymous]
    public async Task<IActionResult> GetProductById(int id)
    {
        var productDetails = await _service.GetByIdAsync(id);

        return View(productDetails);
    }
}
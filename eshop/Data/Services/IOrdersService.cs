using eshop.Models;


namespace eshop.Data.Services;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

    Task<List<Order>> GetOrderSByUserIdAsync(string userId);
    
}
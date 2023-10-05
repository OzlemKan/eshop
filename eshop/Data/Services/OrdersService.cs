using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public class OrdersService : IOrdersService
{
   private readonly AppDbContext _context;

   public OrdersService(AppDbContext context)
   {
      _context = context;
   }

   
   // get all the orders by user id
   public async Task<List<Order>> GetOrderSByUserIdAsync(string userId) 

   {
      var orders = await _context.Orders
         .Include(n => n.OrderItem)
         .ThenInclude(n => n.Products)
         .Where(n => n.UserId == userId).ToListAsync();

      return orders;
   }

   public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)

   {
      var order = new Order()

      {
         UserId = userId,
         Email = userEmailAddress,
      };
      await _context.Orders.AddAsync(order);
      await _context.SaveChangesAsync();

      foreach (var item in items)
      {
         var orderItem = new OrderItem()
         {
            Amount = item.Amount,
            Products = item.Products,
            OrderId = order.OrderId,
            Price = item.Products.ProductPrice
         };

        await _context.OrderItems.AddAsync(orderItem);
      }

      await _context.SaveChangesAsync();
   }
   
}
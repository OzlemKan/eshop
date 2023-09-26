using eshop.Models;


namespace eshop.Data.Services;

public interface IOrdersService
{
    IEnumerable<Order> GetAll();

    Order GetById(int id);

    void Add(Order customers);
    
    Order Update(int id, Order newOrder);

    void Delete(int id);

}
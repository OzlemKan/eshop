using eshop.Models;


namespace eshop.Data.Services;

public interface IOrdersService
{
    IEnumerable<Orders> GetAll();

    Orders GetById(int id);

    void Add(Orders customers);
    
    Orders Update(int id, Orders newOrders);

    void Delete(int id);

}
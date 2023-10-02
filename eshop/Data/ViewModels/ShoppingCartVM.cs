using eshop.Data.Cart;

namespace eshop.Data.ViewModels;

public class ShoppingCartVm
{
    public ShoppingCartVm(ShoppingCart? shoppingCart)
    {
        ShoppingCart = shoppingCart;
    }
    

    public ShoppingCart? ShoppingCart { get; set; }
    public decimal ShoppingCartTotal { get; set; }
    
    
    
}
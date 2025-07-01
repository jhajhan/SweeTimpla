// Services/IOrderService.cs
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        bool CreateOrderFromCart(int userId, int[] cartItemIds, string paymentMethod, string shippingAddress);
    }
}

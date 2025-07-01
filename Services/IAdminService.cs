using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public interface IAdminService
    {
        IEnumerable<Order> GetAllOrders();
        void UpdateOrderStatus(int orderId, string status);
        void DeleteOrder(int orderId);
    }
}

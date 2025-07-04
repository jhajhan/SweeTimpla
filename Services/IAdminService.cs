using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModel;

namespace DIYFilipinoDessert.Services
{
    public interface IAdminService
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<DessertKit> GetAllKits();
        bool EditOrder(EditOrderViewModel model);
        bool DeleteOrder(int orderId);

        bool EditKit(EditDessertKitViewModel model);
        bool DeleteKit(int kitId);
    }
}

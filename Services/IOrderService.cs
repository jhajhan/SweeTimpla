// Services/IOrderService.cs
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModels;

namespace DIYFilipinoDessert.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders(int userId);
        List<Order> GetAllOrders();
        string? GetInstructionFilePath(int dessertKitId);
        public bool CreateOrderFromCart(int userId, OrderViewModel viewModel);
    }
}

using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using Microsoft.EntityFrameworkCore;


namespace DIYFilipinoDessert.Services
{
    public class AdminService: IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.DessertKit)
                .ToList();
            if (orders == null || !orders.Any()) throw new Exception("No orders found");
            return orders;
        }
        public void UpdateOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null) throw new Exception("Order not found");
            order.Status = status;
            _context.SaveChanges();
        }
        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null) throw new Exception("Order not found");
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}

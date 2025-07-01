// Services/OrderService.cs
using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using Microsoft.EntityFrameworkCore;

namespace DIYFilipinoDessert.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.DessertKit)
                .ToList();
        }

        public bool CreateOrderFromCart(int userId, int[] cartItemIds, string paymentMethod, string shippingAddress)
        {
            var cartItems = _context.Carts
                .Include(c => c.DessertKit)
                .Where(c => c.UserId == userId && cartItemIds.Contains(c.Id))
                .ToList();

            if (cartItems == null || cartItems.Count == 0)
                return false;

            var order = new Order
            {
                UserId = userId,
                PaymentMethod = paymentMethod,
                ShippingAddress = shippingAddress,
                TotalAmount = cartItems.Sum(ci => ci.Price),
                OrderDate = DateTime.UtcNow,
                Status = "Pending", // Default status
                Items = cartItems.Select(ci => new OrderItem
                {
                    DessertKitId = ci.DessertKitId,
                    Toppings = ci.Toppings ?? "",
                    Extras = ci.Extras ?? "",
                    Notes = ci.Notes ?? "",
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Carts.RemoveRange(cartItems); // Clear selected items from cart
            _context.SaveChanges();

            return true;
        }
    }
}


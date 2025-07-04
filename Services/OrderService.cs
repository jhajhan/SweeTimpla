// Services/OrderService.cs
using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModels;
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

        public List<Order> GetOrders(int userId)
        {

            return _context.Orders
           .Where(o => o.UserId == userId)
           .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.DessertKit) // include DessertKit data
           .ToList();
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.DessertKit)
                .ToList();
        }

        public string? GetInstructionFilePath(int dessertKitId)
        {
            var dessertKit = _context.DessertKits
                .FirstOrDefault(d => d.Id == dessertKitId);

            return dessertKit?.Instructions; // filename, e.g., "puto-bumbong.pdf"
        }

        public bool CreateOrderFromCart(int userId, OrderViewModel viewModel)
        {
            if (viewModel.SelectedCartIds == null || viewModel.SelectedCartIds.Length == 0)
                return false;

            var cartItems = _context.Carts
                .Include(c => c.DessertKit)
                .Where(c => c.UserId == userId && viewModel.SelectedCartIds.Contains(c.Id))
                .ToList();

            if (cartItems == null || !cartItems.Any())
                return false;

            var order = new Order
            {
                UserId = userId,
                FullName = viewModel.FullName,
                ShippingAddress = viewModel.ShippingAddress,
                ContactNumber = viewModel.ContactNumber,
                PaymentMethod = viewModel.PaymentMethod,
                PaymentStatus = "Unpaid", // Default status
                TotalAmount = cartItems.Sum(c => c.Price * c.Quantity) + 38, // Add shipping
                OrderDate = DateTime.UtcNow,
                OrderItems = cartItems.Select(c => new OrderItem
                {
                    DessertKitId = c.DessertKitId,
                    Quantity = c.Quantity,
                    Price = c.Price,
                    Toppings = c.Toppings,
                    Extras = c.Extras,
                    Notes = c.Notes
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Carts.RemoveRange(cartItems);

            _context.SaveChanges();
            return true;
        }

    }
}


using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModel;
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

        public IEnumerable<DessertKit> GetAllKits()
        {
            var kits = _context.DessertKits
                .ToList();

            return kits;
        }
        // This method is for editing payment status and status of the order
        public bool EditOrder(EditOrderViewModel model)
        {
            var order = _context.Orders.Find(model.Id);
            if (order == null)
                return false;

            order.PaymentStatus = model.PaymentStatus;
            order.Status = model.Status;

            var affectedRows = _context.SaveChanges();
            return affectedRows > 0;
        }

        // This method is for deleting an order
        public bool DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
                return false;
            _context.Orders.Remove(order);
            var affectedRows = _context.SaveChanges();
            return affectedRows > 0;
        }

        //This method is for editing a dessert kit
        public bool EditKit(EditDessertKitViewModel model)
        {
            var kit = _context.DessertKits.Find(model.Id);
            if (kit == null)
                return false;
            kit.Name = model.Name;
            kit.Ingredients = model.Ingredients;
            kit.ToolList = model.ToolList;
            kit.PreparationTime = model.PreparationTime;
            kit.CookingTime = model.CookingTime;
            kit.TotalTime = model.TotalTime;
            kit.ServingSize = model.ServingSize;
            kit.ImageUrl = model.ImageUrl;
            kit.Quantity = model.Quantity;
            kit.IsFeatured = model.IsFeatured;
            kit.Description = model.Description;
            kit.Price = model.Price;
            kit.Instructions = model.Instructions;
            var affectedRows = _context.SaveChanges();
            return affectedRows > 0;
        }

        // This method is for deleting a dessert kit
        public bool DeleteKit(int kitId)
        {
            var kit = _context.DessertKits.Find(kitId);
            if (kit == null)
                return false;
            _context.DessertKits.Remove(kit);
            var affectedRows = _context.SaveChanges();
            return affectedRows > 0;
        }
    }
}

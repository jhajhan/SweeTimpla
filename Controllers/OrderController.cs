using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Data;
using Microsoft.EntityFrameworkCore;

namespace DIYFilipinoDessert.Controllers
{

   public class OrderController: Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }
   
        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.DessertKit)
                .ToList();

            return View(orders);
        }
        //This action will return the view when a customer checkouts/orders 
        //It will accept list of dessert kits and their quantities
        public IActionResult Checkout(List<int> dessertKitIds, List<int> quantities)
        {
            if (dessertKitIds == null || quantities == null || dessertKitIds.Count != quantities.Count)
            {
                return BadRequest("Invalid order data.");
            }
            var order = new Models.Order
            {
                OrderDate = DateTime.Now,
                Items = new List<Models.OrderItem>()
            };
            for (int i = 0; i < dessertKitIds.Count; i++)
            {
                var dessertKitId = dessertKitIds[i];
                var quantity = quantities[i];
                var dessertKit = _context.DessertKits.Find(dessertKitId);
                if (dessertKit != null && quantity > 0)
                {
                    order.Items.Add(new Models.OrderItem
                    {
                        DessertKit = dessertKit,
                        Quantity = quantity
                    });
                }
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

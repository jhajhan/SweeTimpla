using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Data;
using Microsoft.EntityFrameworkCore;
using DIYFilipinoDessert.Services;
using System.Runtime.CompilerServices;
using DIYFilipinoDessert.ViewModels;

namespace DIYFilipinoDessert.Controllers
{

   public class OrderController: AuthenticationController
    {
    
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(ApplicationDbContext context)
        {
            _orderService = new OrderService(context);
            _cartService = new CartService(context);
        }

        public IActionResult Index()
        {

            if (IsUserLoggedIn() is IActionResult redirect)
                return redirect;

            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            var orders = _orderService.GetOrders(userId);
            return View(orders);
        }





        //This action is called when customer confirms their order
        [HttpPost]
        public IActionResult ConfirmCheckout(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {

                return RedirectToAction("Cart", "Index", new { error = "Invalid order details. Please check your input." });
            }


            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();

            // Check if user is logged in
            if (userId == 0)
            {
                TempData["ErrorMessage"] = "You must be logged in to place an order.";
                return RedirectToAction("Login", "Home");
            }

            // Delegate to service
            bool success = _orderService.CreateOrderFromCart(userId, order);

            if (!success)
            {
                TempData["ErrorMessage"] = "Failed to process your order. Please try again.";
                return RedirectToAction("Index", "Cart");
            }

            TempData["SuccessMessage"] = "Your order has been placed successfully! You can track your order and download the instructions from the Orders tab.";
            return RedirectToAction("Index", "Cart");
        }

        // This action download the pdf for the instructions
        [HttpGet]
        public IActionResult DownloadInstructions(int dessertKitId)
        {
            var filePath = _orderService.GetInstructionFilePath(dessertKitId);

            if (string.IsNullOrEmpty(filePath))
                return NotFound("Instructions not found.");

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", filePath);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found on server.");

            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, "application/pdf", Path.GetFileName(fullPath));
        }




    }
}

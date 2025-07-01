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
            IsUserLoggedIn();
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }


        [HttpPost]
        public IActionResult CheckoutSelected(int[] selectedCartIds)
        {
            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            var selectedItems = _cartService.GetCartByIds(userId, selectedCartIds);

            if (!selectedItems.Any())
            {
                return RedirectToAction("Cart");
            }

            var viewModel = new CheckoutViewModel
            {
                CartItems = selectedItems
            };

            return View("Checkout", viewModel);
        }


        //This action is called when customer confirms their order
        [HttpPost]
        public IActionResult ConfirmCheckout(int[] cartItemIds, string PaymentMethod, string ShippingAddress)
        {
            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();

            // Delegate to service
            bool success = _orderService.CreateOrderFromCart(userId, cartItemIds, PaymentMethod, ShippingAddress);

            if (!success)
                return RedirectToAction("Cart", "Cart");

            return RedirectToAction("OrderSuccess");
        }



    }
}

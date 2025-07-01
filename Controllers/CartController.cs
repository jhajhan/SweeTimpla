using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Data;

using Microsoft.EntityFrameworkCore;
using DIYFilipinoDessert.Services;
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Controllers
{
    public class CartController : AuthenticationController
    {


        private readonly CartService _cartService;

        public CartController(ApplicationDbContext context, ILogger<CartController> logger)
        {

            _cartService = new CartService(context);
        }

        //This action will return the view for the Cart page
        public IActionResult Index(int account_id)
        {
            var loginCheck = IsUserLoggedIn();
            if (loginCheck != null)
                return loginCheck;
            // Fetch the cart and the cart items for the given account_id
            var cart = _cartService.GetCartByUserId(account_id);
            return View(cart);
        }

        // This action will process adding an item to the cart
        [HttpPost]
        public IActionResult AddToCartFromKits(int dessertKitId, decimal price)
        {
        

            var cartItem = new Cart
            {
                DessertKitId = dessertKitId,
                UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
                Quantity = 1,
                Price = price,
                Toppings = null,
                Extras = null,
                Notes = null
            };

            _cartService.AddToCart(cartItem);  // ✅ Reusing the same service

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult AddToCartBuild(int kit_id, string[] toppings, string[] extras, string[] notes, decimal price)
        {
            IsUserLoggedIn();
            string toppingsCsv = toppings != null ? string.Join(", ", toppings) : "";
            string extrasCsv = extras != null ? string.Join(", ", extras) : "";

            var cartItem = new Cart
            {
                UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
                DessertKitId = kit_id,
                Quantity = 1, // Default quantity is set to 1
                Price = price,
                Toppings = toppingsCsv,
                Extras = extrasCsv,
                Notes = notes != null ? string.Join(", ", notes) : ""
            };

            _cartService.AddToCart(cartItem);

            return RedirectToAction("Index");

        }

        // This action will process removing an item from the cart
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        // This action will process removing selected items from the cart
        [HttpPost]
        public IActionResult RemoveSelectedItems(List<int> itemIds)
        {
            _cartService.RemoveSelectedItems(itemIds);
            return RedirectToAction("Index");
        }

        // This action will process updating the quantity of an item in the cart 
        [HttpPost]
        public IActionResult UpdateCartItem(int id, int quantity)
        {
            _cartService.UpdateCartItem(id, quantity);
            return RedirectToAction("Index");
        }
    }
}

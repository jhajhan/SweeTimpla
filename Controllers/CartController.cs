using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Data;

using Microsoft.EntityFrameworkCore;
using DIYFilipinoDessert.Services;
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Controllers
{
    public class CartController : AuthenticationController
    {


        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {

            _cartService = cartService;
        }

        //This action will return the view for the Cart page
        public IActionResult Index()
        {
            if (IsUserLoggedIn() is IActionResult redirect)
                return redirect;

            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();

            // Make sure this returns data
            var cartItems = _cartService.GetCartByUserId(userId);

            return View(cartItems); // Must return a List<Cart>
        }


        // This action will process adding an item to the cart
        [HttpPost]
        public IActionResult AddToCart(CartViewModel model)
        {
            if (IsUserLoggedIn() is IActionResult redirect)
                return redirect;

            Console.WriteLine("Adding to cart: " + model.DessertKitId + ", Price: " + model.Price);

            if (model.DessertKitId <= 0 || model.Price <= 0)
            {
                ModelState.AddModelError("", "Invalid kit or price.");
                return View("Index"); // or return RedirectToAction with error TempData
            }

            var cartItem = new Cart
            {
                UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
                DessertKitId = model.DessertKitId,
                Quantity = 1,
                Price = model.Price,
                Toppings = model.Toppings != null ? string.Join(", ", model.Toppings) : null,
                Extras = model.Extras != null ? string.Join(", ", model.Extras) : null,
                Notes = model.Notes != null ? string.Join(", ", model.Notes) : null
            };

            _cartService.AddToCart(cartItem);

            TempData["SuccessMessage"] = "Item added to cart!";
            return RedirectToAction("Index", "Cart");
        }


        // This action will process removing an item from the cart
        public IActionResult RemoveFromCart(int Id)
        {
            _cartService.RemoveFromCart(Id);
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
        public IActionResult UpdateQuantity(int Id, string action)
        {
            int delta = action == "increase" ? 1 : -1;
            _cartService.UpdateCartItem(Id, delta);
            return RedirectToAction("Index");
        }

    }
}

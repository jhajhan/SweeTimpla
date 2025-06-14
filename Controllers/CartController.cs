using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Data;

using Microsoft.EntityFrameworkCore;

namespace DIYFilipinoDessert.Controllers
{
    public class CartController : Controller
    {

        private readonly ILogger<CartController> _logger;
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context, ILogger<CartController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //This action will return the view for the Cart page
        public IActionResult Index(int account_id)
        {
            // Fetch the cart and the cart items for the given account_id
            var cart = _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.DessertKit)
                .FirstOrDefault(c => c.UserId == account_id);

            return View(cart);
        }

        // This action will process adding an item to the cart
        [HttpPost]
        public IActionResult AddToCart(int id, int user_id)
        {
            var dessertKit = _context.DessertKits.Find(id);
            if (dessertKit == null)
            {
                return NotFound();
            }
            // Check if the cart exists for the user, if not create one
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == user_id);
            if (cart == null)
            {
                cart = new Models.Cart { UserId = user_id};
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            // Add the dessert kit to the cart
            var cartItem = new Models.CartItem
            {
                DessertKit = dessertKit,
                Id = cart.Id,
                Quantity = 1 // Default quantity is 1
            };
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // This action will process removing an item from the cart
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // This action will process removing selected items from the cart
        [HttpPost]
        public IActionResult RemoveSelectedItems(List<int> itemIds)
        {
            if (itemIds == null || !itemIds.Any())
            {
                return BadRequest("No items selected for removal.");
            }
            var cartItems = _context.CartItems.Where(ci => itemIds.Contains(ci.Id)).ToList();
            if (!cartItems.Any())
            {
                return NotFound("No items found for the provided IDs.");
            }
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // This action will process updating the quantity of an item in the cart 
        [HttpPost]
        public IActionResult UpdateCartItem(int id, int quantity)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            if (quantity <= 0)
            {
                _context.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
                _context.CartItems.Update(cartItem);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

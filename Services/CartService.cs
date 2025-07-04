// Services/CartService.cs
using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using Microsoft.EntityFrameworkCore;

namespace DIYFilipinoDessert.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        //return cart items of the user
        public List<Cart> GetCartByUserId(int userId)
        {
            return _context.Carts
                .Include(c => c.DessertKit) // 👈 this is what makes DessertKit work!
                .Where(c => c.UserId == userId)
                .ToList();
        }


        // This method is used to get cart items by their IDs
        public List<Cart> GetCartByIds(int userId, int[] cartItemIds)
        {
            return _context.Carts
                .Include(c => c.DessertKit)
                .Where(c => c.UserId == userId && cartItemIds.Contains(c.Id))
                .ToList();
        }

        public void AddToCart(Cart cartItem)
        {
            var existingCart = _context.Carts.FirstOrDefault(c =>
                                c.UserId == cartItem.UserId &&
                                c.DessertKitId == cartItem.DessertKitId &&
                                c.Toppings == cartItem.Toppings &&
                                c.Extras == cartItem.Extras &&
                                c.Notes == cartItem.Notes);


            if (existingCart != null)
            {
                existingCart.Quantity += cartItem.Quantity;
                existingCart.Price += cartItem.Price;
            }
            else
            {
                _context.Carts.Add(cartItem);
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int cartItemId)
        {
            var cartItem = _context.Carts.Find(cartItemId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void RemoveSelectedItems(List<int> itemIds)
        {
            var items = _context.Carts.Where(ci => itemIds.Contains(ci.Id)).ToList();
            _context.Carts.RemoveRange(items);
            _context.SaveChanges();
        }

        public void UpdateCartItem(int cartItemId, int delta)
        {
            var cartItem = _context.Carts.Find(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity += delta;

                if (cartItem.Quantity <= 0)
                {
                    _context.Carts.Remove(cartItem);
                }
                else
                {
                    _context.Carts.Update(cartItem);
                }

                _context.SaveChanges();
            }
        }

    }
}

// Services/ICartService.cs
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public interface ICartService
    {
        List<Cart> GetCartByUserId(int userId);
        List<Cart> GetCartByIds(int userId, int[] cartItemIds);
        void AddToCart(Cart cart);
        void RemoveFromCart(int cartItemId);
        void RemoveSelectedItems(List<int> itemIds);
        void UpdateCartItem(int cartItemId, int delta);
    }
}

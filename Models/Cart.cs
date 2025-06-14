namespace DIYFilipinoDessert.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Assuming a user can have only one cart
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation property
        public Account User { get; set; }
    }
}

namespace DIYFilipinoDessert.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int DessertKitId { get; set; } // Assuming a cart is associated with a specific dessert kit
        public DessertKit? DessertKit { get; set; } // Navigation property
        public int UserId { get; set; } // Assuming a user can have only one cart

        public int Quantity { get; set; } = 1; // Default quantity is 1
        public decimal Price { get; set; } // Total price of the cart

        public string? Toppings { get; set; }
        public string? Extras { get; set; }
        public string? Notes { get; set; } // Additional notes for the cart
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation property
      
    }
}

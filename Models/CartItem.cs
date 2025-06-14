namespace DIYFilipinoDessert.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int DessertKitId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Navigation property
        public DessertKit DessertKit { get; set; }

    }
}

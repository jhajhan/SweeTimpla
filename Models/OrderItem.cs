namespace DIYFilipinoDessert.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DessertKitId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string? Toppings { get; set; }
        public string? Extras { get; set; }
        public string? Notes { get; set; } 
        // Navigation properties
        public Order Order { get; set; }
        public DessertKit DessertKit { get; set; }
    }
}

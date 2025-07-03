namespace DIYFilipinoDessert.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string ShippingAddress { get; set; }
        public string ContactNumber { get; set; }

        public string FullName { get; set; } // Full name of the customer

        public string PaymentMethod { get; set; }

        public decimal TotalAmount { get; set; } // Total amount for the order

        public string Status { get; set; } = "Pending"; // e.g., "Pending", "Shipped", "Delivered"
        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}

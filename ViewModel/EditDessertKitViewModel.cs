namespace DIYFilipinoDessert.ViewModel
{
    public class EditDessertKitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ToolList { get; set; }
        public string PreparationTime { get; set; }
        public string CookingTime { get; set; }
        public string? TotalTime { get; set; }
        public string ServingSize { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string? Instructions { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public bool IsFeatured { get; set; } = false;

    }
}

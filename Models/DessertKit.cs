namespace DIYFilipinoDessert.Models
{
    public class DessertKit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsFeatured { get; set; } = false;
        // Navigation property for related recipes
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    }
}

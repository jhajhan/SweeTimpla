
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;


namespace DIYFilipinoDessert.Models
{
    public class DessertKit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Ingredients { get; set; } = string.Empty;
        public string ToolList { get; set; } = string.Empty;
        public string PreparationTime { get; set; } = string.Empty; // e.g., "30 minutes"
        public string CookingTime { get; set; } = string.Empty; // e.g., "1 hour"
        public string? TotalTime { get; set; }  // e.g., "1 hour 30 minutes"
        public string ServingSize { get; set; } = string.Empty; // e.g., "4 servings"

        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Instructions { get; set; } 
        public int? Quantity { get; set; }
        public bool IsFeatured { get; set; } = false;
        // Navigation property for related recipes
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    }
}

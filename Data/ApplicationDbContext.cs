using DIYFilipinoDessert.Models;
using Microsoft.EntityFrameworkCore;

namespace DIYFilipinoDessert.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DessertKit> DessertKits { get; set; }
        public DbSet<Recipe> RecipeSteps { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Account> Accounts { get; set; }





    }

}

namespace DIYFilipinoDessert.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

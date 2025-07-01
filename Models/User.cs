namespace DIYFilipinoDessert.Models
{
    // 🧱 Abstract base class
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public abstract string AccessInterface();
    }

    // 👤 Customer subclass
    public class Customer : User
    {
        public override string AccessInterface()
        {
            return "/";
        }
    }

    // 🛠 Admin subclass
    public class Admin : User
    {
        public override string AccessInterface()
        {
            return "/Admin";
        }
    }
}

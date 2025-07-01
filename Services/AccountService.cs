using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var account = _context.Accounts
                .FirstOrDefault(a => a.Username == username && a.Password == password);

            if (account == null) return null;

            return account.Role switch
            {
                "Admin" => new Admin { Id = account.Id, Username = account.Username },
                _ => new Customer { Id = account.Id, Username = account.Username }
            };
        }

        public bool Register(Account account)
        {
            if (_context.Accounts.Any(a => a.Username == account.Username || a.Email == account.Email || a.Password == account.Password))
                return false;

            account.CreatedAt = DateTime.UtcNow;
            account.Role = "customer";
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return true;
        }

        public Account GetAccount(string username, string password)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}

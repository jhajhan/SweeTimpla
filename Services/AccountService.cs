using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace DIYFilipinoDessert.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            var account = _context.Accounts.FirstOrDefault(u => u.Email == email);
            if (account == null)
                return null;

            var hasher = new PasswordHasher<LoginViewModel>();
            var result = hasher.VerifyHashedPassword(new LoginViewModel(), account.Password, password);

            if (result != PasswordVerificationResult.Success)
                return null;

            // Return polymorphic User
            return account.Role switch
            {
                "Admin" => new Admin { Id = account.Id, Username = account.Username, Email = account.Email },
                _ => new Customer { Id = account.Id, Username = account.Username, Email = account.Email }
            };
        }


        public bool Register(RegisterViewModel account)
        {
            if (_context.Accounts.Any(a => a.Username == account.Username || a.Email == account.Email))
                return false;

            var hasher = new PasswordHasher<RegisterViewModel>();
            var hashedPassword = hasher.HashPassword(account, account.Password);

            var newAccount = new Account
            {
                Username = account.Username,
                Email = account.Email,
                Password = hashedPassword,
                Role = "customer",
                CreatedAt = DateTime.UtcNow
            };

            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return true;
        }


        public Account GetAccount(int userId)
        {
            return _context.Accounts.Find(userId);
        }

        public bool EditDetails(EditDetailsViewModel model)
        {
            var account = _context.Accounts.Find(model.Id);
            if (account == null)
                return false;

            account.Username = model.FullName;
            account.Email = model.Email;

            _context.Accounts.Update(account);
            _context.SaveChanges();

            return true;
        }


        public bool ChangePassword(ChangePasswordViewModel model)
        {
            var account = _context.Accounts.Find(model.Id);
            if (account == null)
                return false;

            var hasher = new PasswordHasher<ChangePasswordViewModel>();
            var result = hasher.VerifyHashedPassword(model, account.Password, model.OldPassword);

            if (result != PasswordVerificationResult.Success)
                return false;

            account.Password = hasher.HashPassword(model, model.NewPassword);
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return true;
        }

        public bool UserExists(string email, string password)
        {
            return _context.Accounts.Any(a => a.Email == email || a.Password == password);
        }
    }
}

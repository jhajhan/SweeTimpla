using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModel;

namespace DIYFilipinoDessert.Services
{
    public interface IAccountService
    {
        User Authenticate(string username, string password);
        bool Register(RegisterViewModel account);
        Account GetAccount(string username, string password);
        bool UserExists(string email, string password);
    }
}

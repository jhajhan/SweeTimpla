using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public interface IAccountService
    {
        User Authenticate(string username, string password);
        bool Register(Account account);
        Account GetAccount(string username, string password);
    }
}

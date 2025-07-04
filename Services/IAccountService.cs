using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.ViewModel;

namespace DIYFilipinoDessert.Services
{
    public interface IAccountService
    {
        User Authenticate(string username, string password);
        bool Register(RegisterViewModel account);
        Account GetAccount(int userId);
        bool EditDetails(EditDetailsViewModel model);
        bool ChangePassword(ChangePasswordViewModel model);

        bool UserExists(string email, string password);
    }
}

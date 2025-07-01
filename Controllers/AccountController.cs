using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        public IActionResult Index() => View();

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _accountService.Authenticate(username, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("UserRole", user.GetType().Name);

                return Redirect(user.AccessInterface()); // polymorphic redirection
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View("Index");
        }

        [HttpPost]
        public IActionResult Registration(Account account)
        {
            if (ModelState.IsValid)
            {
                var registered = _accountService.Register(account);
                if (!registered)
                {
                    ModelState.AddModelError("", "Username or Email already exists.");
                    return View("Register");
                }

                return RedirectToAction("Index");
            }
            return View(account);
        }

        public IActionResult Profile(string username, string password)
        {
            var account = _accountService.GetAccount(username, password);
            if (account == null)
                return NotFound();

            return View(account);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

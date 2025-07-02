using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

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

      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewBag.ErrorMessage = "Please fill in all fields.";
                return View();
            }

            var user = _accountService.Authenticate(Email, Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("UserRole", user.Role);
                return Redirect(user.AccessInterface());
            }

            ViewBag.ErrorMessage = "Invalid email or password.";
            return View();
        }

     
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
                return View(registerModel);

            var exists = _accountService.UserExists(registerModel.Username, registerModel.Email);
            if (exists)
            {
                ViewBag.ErrorMessage = "Username or Email already exists.";
                return View(registerModel);
            }

            var registered = _accountService.Register(registerModel);
            if (!registered)
            {
                ViewBag.ErrorMessage = "Registration failed. Try again.";
                return View(registerModel);
            }

            TempData["SuccessMessage"] = "Registration successful! Please log in.";
            return RedirectToAction("Login");
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Data;

namespace DIYFilipinoDessert.Controllers;

using DIYFilipinoDessert.Services;
using DIYFilipinoDessert.ViewModel;

public class HomeController : Controller
{

    private readonly IDessertKitService _dessertKitService;
    private readonly IAccountService _accountService;

    public HomeController (ApplicationDbContext context, ILogger<HomeController> logger)
    {

        _dessertKitService = new DessertKitService(context);
        _accountService = new AccountService(context);
    }

    public IActionResult Index()
    {
        var featuredKits = _dessertKitService.GetFeaturedDessertKits();
        return View(featuredKits);
    }

    public IActionResult Login()
    {
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
            ModelState.AddModelError(string.Empty, "Username or Email already exists.");
            return View(registerModel);
        }

        var registered = _accountService.Register(registerModel);
        if (!registered)
        {
            ModelState.AddModelError(string.Empty, "Registration failed. Try again.");
            return View(registerModel);
        }

        TempData["SuccessMessage"] = "Registration successful! Please log in.";
        return RedirectToAction("Login");
    }


    [HttpPost]
    public IActionResult Login(string Email, string Password)
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            ModelState.AddModelError(string.Empty, "Please fill in all fields.");
            return View();
        }

        var user = _accountService.Authenticate(Email, Password);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Email", user.Email);
            string role = user is Admin ? "admin" :
                 user is Customer ? "customer" : "unknown";

            HttpContext.Session.SetString("UserRole", role);

            return Redirect(user.AccessInterface());
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password.");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["SuccessMessage"] = "You have been logged out successfully.";
        return RedirectToAction("Login", "Home");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

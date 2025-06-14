using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AccountController : Controller
    {

		private readonly ILogger<AccountController> _logger;
		private readonly ApplicationDbContext _context;

		public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
		{
			_context = context;
			_logger = logger;
		}
		// This action will return the view for the Account page
		// It can be used for login, registration, etc.
		// Default is login page
		public IActionResult Index()
		{
			return View();
		}

		// This action will return the view for the Registration page
		public IActionResult Register()
		{
			return View();
		}

		// This action processes the login process
		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			var is_valid = _context.Accounts
				.Any(a => a.Username == username && a.Password == password);

			if (is_valid)
			{
				// Set session or cookie for logged in user
				HttpContext.Session.SetString("Username", username);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Invalid username or password.");
				return View("Index");
			}
		}

		// This action processes the registration process
		[HttpPost]
		public IActionResult Registration (Account account)
		{
			if (ModelState.IsValid)
			{
				// Save the account to the database
				account.CreatedAt = DateTime.UtcNow;
				_context.Accounts.Add(account);
				_context.SaveChanges();
				// Redirect to login page after successful registration
				return RedirectToAction("Index");
			}
			return View(account);
		}

		// This action will return the view for the Profile page
		public IActionResult Profile (string username, string password) {
			var account = _context.Accounts
				.FirstOrDefault(a => a.Username == username && a.Password == password);
			if (account == null)
			{
				return NotFound();
			}
			return View(account);
		}

		//This action will log out the user
		public IActionResult Logout()
		{
			// Clear session or cookie for logged out user
			HttpContext.Session.Remove("Username");
			return RedirectToAction("Index", "Home");
		}
	}

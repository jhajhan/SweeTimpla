using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Services;
using DIYFilipinoDessert.ViewModel;

namespace DIYFilipinoDessert.Controllers
{
    public class ProfileController: Controller
    {

        private readonly IAccountService _accountService;

        public ProfileController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            var account = _accountService.GetAccount(userId);

            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult EditDetails(EditDetailsViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
       
            var success = _accountService.EditDetails(model);

            if (!success)
            {
                ModelState.AddModelError("", "Failed to update details. Please try again.");
                return View("Index", model);
            }

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            var success = _accountService.ChangePassword(model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to change password. Please try again.");
                return View("Index", model);
            }
            TempData["SuccessMessage"] = "Password changed successfully!";
            return RedirectToAction("Index", "Profile");
        }
    }
}

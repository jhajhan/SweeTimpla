using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AuthenticationController : Controller
    {

        protected IActionResult? IsUserLoggedIn()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Home");
            }
            return null;
        }


    }
}


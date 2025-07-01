using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

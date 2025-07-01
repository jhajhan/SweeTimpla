using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class BuildYourOwnController : Controller
    {

        private readonly IDessertKitService _dessertKitService;

        public BuildYourOwnController(ApplicationDbContext context)
        {
            _dessertKitService = new DessertKitService(context);
        }
         
        public IActionResult Index()
        {

            var dessertKits = _dessertKitService.GetAllDessertKits();
            return View(dessertKits);
        }
    }
}

using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class BuildYourOwnController : Controller
    {

        private readonly IDessertKitService _dessertKitService;

        public BuildYourOwnController(IDessertKitService dessertKitService)
        {
            _dessertKitService = dessertKitService;
        }
         
        public IActionResult Index()
        {

            var dessertKits = _dessertKitService.GetAllDessertKits();
            return View(dessertKits);
        }
    }
}

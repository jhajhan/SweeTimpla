using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class DessertKitController : Controller
    {

   
        private readonly IDessertKitService _dessertKitService;

        public DessertKitController(ApplicationDbContext context, ILogger<DessertKitController> logger)
        {

            _dessertKitService = new DessertKitService(context);
        }

        public IActionResult Index()
        {
            // This action will return the view for the Dessert Kit page
            var dessertkits = _dessertKitService.GetAllDessertKits();
            return View(dessertkits);
        }

        [HttpGet]
        public IActionResult GetKitDetails(int kitId)
        {
            // print id
           
            Console.WriteLine($"Fetching details for kit ID: {kitId}");
            var kit = _dessertKitService.GetDessertKitById(kitId); // or however you fetch the kit
            if (kit == null) return NotFound();

            return Json(new
            {
                name = kit.Name,
                includes = kit.Ingredients,        // customize field names as needed
                tools = kit.ToolList,
                prepTime = kit.PreparationTime,
                cookTime = kit.CookingTime,
                totalTime = kit.TotalTime,
                servings = kit.ServingSize,
                price = kit.Price,

            });
        }

    }
}

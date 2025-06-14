using DIYFilipinoDessert.Data;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class DessertKitController : Controller
    {

        private readonly ILogger<DessertKitController> _logger;
        private readonly ApplicationDbContext _context;

        public DessertKitController(ApplicationDbContext context, ILogger<DessertKitController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // This action will return the view for the Dessert Kit page
            var dessertkits = _context.DessertKits.ToList();
            return View(dessertkits);
        }

        public IActionResult Details(int id)
        {
            // This action will return the details of a specific Dessert Kit
            var dessertKit = _context.DessertKits.Find(id);
            if (dessertKit == null)
            {
                return NotFound();
            }
            return View(dessertKit);
        }
    }
}

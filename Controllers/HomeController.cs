using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Data;

namespace DIYFilipinoDessert.Controllers;

using DIYFilipinoDessert.Services;
public class HomeController : Controller
{

    private readonly IDessertKitService _dessertKitService;

    public HomeController (ApplicationDbContext context, ILogger<HomeController> logger)
    {

        _dessertKitService = new DessertKitService(context);
    }

    public IActionResult Index()
    {
        var featuredKits = _dessertKitService.GetFeaturedDessertKits();
        return View(featuredKits);
    }

 
   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

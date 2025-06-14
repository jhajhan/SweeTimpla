using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Data;

namespace DIYFilipinoDessert.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController (ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var featuredKits = _context.DessertKits.Where(k => k.IsFeatured).Take(5).ToList();
        return View(featuredKits);
    }

 
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// Services/IDessertKitService.cs
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.Services
{
    public interface IDessertKitService
    {
        List<DessertKit> GetAllDessertKits();
        DessertKit? GetDessertKitById(int id);
        List<DessertKit> GetFeaturedDessertKits(); // ✅ NEW METHOD
    }
}

// Services/DessertKitService.cs
using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using System.Collections.Generic;
using System.Linq;

namespace DIYFilipinoDessert.Services
{
    public class DessertKitService : IDessertKitService
    {
        private readonly ApplicationDbContext _context;

        public DessertKitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DessertKit> GetAllDessertKits()
        {
            return _context.DessertKits.ToList();
        }

        public DessertKit? GetDessertKitById(int id)
        {
            return _context.DessertKits.Find(id);
        }

        public List<DessertKit> GetFeaturedDessertKits() // ✅ IMPLEMENTED HERE
        {
            return _context.DessertKits
                .Where(kit => kit.IsFeatured)
                .ToList();
        }
    }
}

using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AdminController: Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // This action will return the view for the Admin Dashboard
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Admin")
            {
                return RedirectToAction("AccessDenied", "Account"); 
            }

            var orders = _adminService.GetAllOrders();
            return View(orders);
        }
        // This action will process updating the status of an order
        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            _adminService.UpdateOrderStatus(orderId, status);
            return RedirectToAction("Index");
        }

        // This action will process deleting an order
        [HttpPost]
        public IActionResult DeleteOrder(int orderId)
        {
            _adminService.DeleteOrder(orderId);
            return RedirectToAction("Index");
        }
    }


}


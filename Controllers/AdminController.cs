using DIYFilipinoDessert.Data;
using DIYFilipinoDessert.Models;
using DIYFilipinoDessert.Services;
using DIYFilipinoDessert.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DIYFilipinoDessert.Controllers
{
    public class AdminController: Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(ApplicationDbContext context)
        {
            _adminService = new AdminService(context);
        }
        // This action will return the view for the Admin Dashboard
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");

            }


            return View();
        }

        // This action will return the view for Order Management 
        public IActionResult ManageOrders()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");

            }

            var orders = _adminService.GetAllOrders();
            return View(orders);
        }

        // This action will edit the order
        [HttpPost]
        public IActionResult EditOrder(EditOrderViewModel model)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var result = _adminService.EditOrder(model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Order updated successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to update order.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid data provided.";
            }

            return RedirectToAction("ManageOrders");
        }

        // This action will delete the order
        [HttpPost]
        public IActionResult DeleteOrder(int Id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result = _adminService.DeleteOrder(Id);
            if (result)
            {
                TempData["SuccessMessage"] = "Order deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete order.";
            }
            return RedirectToAction("ManageOrders");
        }

        public IActionResult ManageKits()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");

            }

            var kits = _adminService.GetAllKits();
            return View(kits);
        }

        //This action will edit a dessert kit
        [HttpPost]
        public IActionResult EditKit(EditDessertKitViewModel model)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var result = _adminService.EditKit(model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Kit updated successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to update kit.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid data provided.";
            }
            return RedirectToAction("ManageKits");
        }

        // This action will delete a dessert kit
        [HttpPost]
        public IActionResult DeleteKit(int Id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result = _adminService.DeleteKit(Id);
            if (result)
            {
                TempData["SuccessMessage"] = "Kit deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete kit.";
            }
            return RedirectToAction("ManageKits");
        }

    }


}


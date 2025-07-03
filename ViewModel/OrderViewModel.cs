using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.ViewModels
{
    public class OrderViewModel
    {
        public int[] SelectedCartIds { get; set; } // IDs of selected cart items

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Shipping address is required.")]
        public string ShippingAddress { get; set; }
        public string ContactNumber { get; set; }
        public string FullName { get; set; }
    }
}

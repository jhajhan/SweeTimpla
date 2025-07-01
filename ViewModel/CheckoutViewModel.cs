using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DIYFilipinoDessert.Models;

namespace DIYFilipinoDessert.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Cart> CartItems { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Shipping address is required.")]
        public string ShippingAddress { get; set; }
    }
}

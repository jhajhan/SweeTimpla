using System.ComponentModel.DataAnnotations;

namespace DIYFilipinoDessert.ViewModel
{
    public class EditDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

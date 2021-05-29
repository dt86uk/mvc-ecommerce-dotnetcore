using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Email required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MinLength(3, ErrorMessage = "Email Address must be longer than 3 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [MinLength(8, ErrorMessage = "Password must be longer than 8 characters")]
        //TODO: [RegEx Here - CustomValidator, must contain one number one upper, one lower and a number]
        public string Password { get; set; }
    }
}
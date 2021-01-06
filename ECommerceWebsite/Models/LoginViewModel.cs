using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Email required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MinLength(3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [MinLength(8)]
        //TODO: [RegEx Here - CustomValidator, must contain one number one upper, one lower and a number]
        public string Password { get; set; }
    }
}
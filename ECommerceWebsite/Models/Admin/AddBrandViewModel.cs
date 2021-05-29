using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class AddBrandViewModel : AdminBaseViewModel
    {
        [Required(ErrorMessage = "Brand Name required")]
        [Display(Name = "Brand Name")]
        [MinLength(3, ErrorMessage = "Brand Name must be longer than 3 characters")]
        public string BrandName { get; set; }
    }
}
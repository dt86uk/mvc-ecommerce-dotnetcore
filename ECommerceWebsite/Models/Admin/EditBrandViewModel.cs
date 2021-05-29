using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class EditBrandViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand Name required")]
        [Display(Name = "Brand Name")]
        [MinLength(2, ErrorMessage = "Brand Name must be longer than 2 characters")]
        public string BrandName { get; set; }
    }
}
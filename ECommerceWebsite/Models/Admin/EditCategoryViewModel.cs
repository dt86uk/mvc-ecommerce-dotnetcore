using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Category Name required")]
        [Display(Name = "Category Name")]
        [MinLength(2, ErrorMessage = "Category Name must be longer than 2 characters")]
        public string CategoryName{ get; set; }
    }
}
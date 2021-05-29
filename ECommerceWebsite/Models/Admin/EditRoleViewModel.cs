using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class EditRoleViewModel : AdminBaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role ")]
        [Display(Name = "Role Name")]
        [MinLength(5, ErrorMessage = "Role Name must be longer than 5 characters")]
        public string RoleName { get; set; }
    }
}
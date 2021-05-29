using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWebsite.Models
{
    public class EditUserViewModel : AdminBaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email Address required")]
        [Display(Name = "Email Address")]
        [MinLength(3, ErrorMessage = "Email Address must be longer than 3 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth Day required")]
        [Display(Name = "Date of Birth")]
        [MaxLength(2, ErrorMessage = "Date of Birth Year can not be more than 2 characters.")]
        public string DateOfBirthDay { get; set; }

        [Required(ErrorMessage = "Date of Birth Month required")]
        [MaxLength(2, ErrorMessage = "Date of Birth Year can not be more than 2 characters.")]
        public string DateOfBirthMonth { get; set; }

        [Required(ErrorMessage = "Date of Birth Year required")]
        [MaxLength(4, ErrorMessage = "Date of Birth Year can not be more than 4 characters.")]
        public string DateOfBirthYear { get; set; }

        [Display(Name = "Roles")]
        public List<SelectListItem> Roles { get; set; }
        
        [Required(ErrorMessage = "Role required")]
        public string SelectedRole { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
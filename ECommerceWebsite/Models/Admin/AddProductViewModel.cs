using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebsite.Models.Admin
{
    public class AddProductViewModel : AdminBaseViewModel
    {
        public BaseWebServiceResponse ActionResponse { get; set; }
        
        public AddProductViewModel() 
        {
            Brands = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
            Sizes = new List<SelectListItem>();
            ProductTypes = new List<SelectListItem>();
        }

        /// <summary>
        /// Initializes the ActionResponse with the response parameter object
        /// </summary>
        /// <param name="response"></param>
        public AddProductViewModel(BaseWebServiceResponse response) 
        {
            ActionResponse = response;
            Brands = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
            Sizes = new List<SelectListItem>();
            ProductTypes = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "Product Name required")]
        [Display(Name = "Product Name")]
        [MinLength(3)]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Category required")]
        public string SelectedCategory { get; set; }

        [Required(ErrorMessage = "Description required")]
        [Display(Name = "Description")]
        [MinLength(3)]
        public string Description { get; set; }

        [Display(Name = "Gender")]
        public List<SelectListItem> Genders { get; set; }
        
        [Required(ErrorMessage = "Gender required")]
        public string SelectedGender { get; set; }

        [Display(Name = "Hero Image")]
        public IFormFile HeroImage { get; set; }

        [Display(Name = "Hero Title")]
        public string HeroTitle { get; set; }

        [Display(Name = "Images")]
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }

        [Display(Name = "Brand")]
        public List<SelectListItem> Brands { get; set; }
        
        [Required(ErrorMessage = "Brand required")]
        public string SelectedBrand { get; set; }

        [Required(ErrorMessage = "Sizes required")]
        [Display(Name = "Sizes")]
        public List<SelectListItem> Sizes { get; set; }

        [Display(Name = "Product Type")]
        public List<SelectListItem> ProductTypes { get; set; }

        [Required(ErrorMessage = "Product Type required")]
        public string SelectedProductType { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Display(Name = "Price Type")]
        [MinLength(1)]
        public string Price { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            Images = new List<ProductImageViewModel>();
            Sizes = new List<ProductSizeViewModel>();
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
            Images = new List<ProductImageViewModel>();
            Sizes = new List<ProductSizeViewModel>();
            ProductTypes = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "Product Name required")]
        [Display(Name = "Product Name")]
        [MinLength(3)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category required")]
        [Display(Name = "Category")]
        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Description required")]
        [Display(Name = "Description")]
        [MinLength(3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Gender required")]
        [Display(Name = "Gender")]
        public List<SelectListItem> Genders { get; set; }

        [Required(ErrorMessage = "Hero Image required")]
        [Display(Name = "Hero Image")]
        public byte[] HeroImage { get; set; }

        [Required(ErrorMessage = "Gender required")]
        [Display(Name = "Gender")]
        public string HeroTitle { get; set; }

        [Required(ErrorMessage = "Images required")]
        [Display(Name = "Images")]
        public List<ProductImageViewModel> Images { get; set; }

        [Required(ErrorMessage = "Brand required")]
        [Display(Name = "Brand")]
        public List<SelectListItem> Brands { get; set; }

        [Required(ErrorMessage = "Sizes required")]
        [Display(Name = "Sizes")]
        public List<ProductSizeViewModel> Sizes { get; set; }

        [Required(ErrorMessage = "Product Type required")]
        [Display(Name = "Product Type")]
        public List<SelectListItem> ProductTypes { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Display(Name = "Price Type")]
        [MinLength(1)]
        public decimal Price { get; set; }
    }
}
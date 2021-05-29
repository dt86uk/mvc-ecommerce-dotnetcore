using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class EditProductViewModel : AdminBaseViewModel
    {
        public EditProductViewModel()
        {
            Brands = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
            ProductTypes = new List<SelectListItem>();
            ImagesSrc = new List<string>();
        }

        /// <summary>
        /// Initializes the ActionResponse with the response parameter object
        /// </summary>
        /// <param name="response"></param>
        public EditProductViewModel(BaseWebServiceResponse response)
        {
            ActionResponse = response;
            Brands = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
            ProductTypes = new List<SelectListItem>();
            ImagesSrc = new List<string>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name required")]
        [Display(Name = "Product Name")]
        [MinLength(3, ErrorMessage = "Product Name must be longer than 3 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Category required")]
        public string SelectedCategory { get; set; }

        [Required(ErrorMessage = "Description required")]
        [Display(Name = "Description")]
        [MinLength(3, ErrorMessage = "Description must be longer than 3 characters")]
        public string Description { get; set; }

        [Display(Name = "Gender")]
        public List<SelectListItem> Genders { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public string SelectedGender { get; set; }

        [Display(Name = "Hero Image")]
        public IFormFile HeroImage { get; set; }

        public byte[] HeroImageCurrent { get; set; }

        [Display(Name = "Hero Title")]
        public string HeroTitle { get; set; }

        //TODO: Make this into a collection of IFormFile => then we can add as many as we like
        [Display(Name = "Images")]
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }

        public List<string> ImagesSrc { get; set; } = new List<string>();

        public List<byte[]> ImagesBytes { get; set; } = new List<byte[]>();

        [Display(Name = "Brand")]
        public List<SelectListItem> Brands { get; set; }

        [Required(ErrorMessage = "Brand required")]
        public string SelectedBrand { get; set; }

        public List<ProductSizeViewModel> Sizes { get; set; }

        [Required(ErrorMessage = "Sizes required")]
        [Display(Name = "Sizes")]
        public string SizesJson { get; set; }

        [Display(Name = "Product Type")]
        public List<SelectListItem> ProductTypes { get; set; }

        [Required(ErrorMessage = "Product Type required")]
        public string SelectedProductType { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Display(Name = "Price Type")]
        public string Price { get; set; }

        [Display(Name = "Is Product Live?")]
        public bool IsActive { get; set; }
    }
}
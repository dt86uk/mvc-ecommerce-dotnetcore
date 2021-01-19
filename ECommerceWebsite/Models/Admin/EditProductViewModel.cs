using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class EditProductViewModel : AdminBaseViewModel
    {
        //TODO: Data Annotations added here / Copy AddProductViewModel
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public CategoryItemViewModel Category { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public byte[] HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public List<ProductImageViewModel> Images { get; set; }
        public BrandViewModel Brand { get; set; }
        public List<ProductSizeViewModel> Sizes { get; set; }
        public ProductTypeViewModel ProductType { get; set; }
        public decimal Price { get; set; }
    }
}
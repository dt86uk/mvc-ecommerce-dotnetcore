using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public CategoryDTO Category { get; set; }
        public string Description { get; set; }
        public byte[] HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public virtual List<ProductImageDTO> Images { get; set; }
        public virtual BrandDTO Brand { get; set; }
        public virtual List<ProductSizeDTO> Sizes { get; set; }
        public virtual ProductTypeDTO ProductType { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
    }
}
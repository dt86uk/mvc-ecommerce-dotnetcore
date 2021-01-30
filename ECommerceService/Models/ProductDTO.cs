using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Images = new List<ProductImageDTO>();
            Sizes = new List<ProductSizeDTO>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public string Description { get; set; }
        public byte[] HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public virtual List<ProductImageDTO> Images { get; set; }

        public int BrandId { get; set; }
        public virtual BrandDTO Brand { get; set; }

        public virtual List<ProductSizeDTO> Sizes { get; set; }

        public int ProductTypeId { get; set; }
        public virtual ProductTypeDTO ProductType { get; set; }

        public decimal Price { get; set; }
        public string Url { get; set; }
    }
}
using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class AddProductContentsDTO
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<GenderDTO> Genders { get; set; }
        public List<BrandDTO> Brands { get; set; }
        public List<ProductSizeDTO> Sizes { get; set; }
        public List<ProductTypeDTO> ProductTypes { get; set; }
    }
}
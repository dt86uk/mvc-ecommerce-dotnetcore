using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceWebsite.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public string ProductName { get; set; }
        public CategoryItemViewModel Category { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public byte[] HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public virtual List<ProductImageViewModel> Images { get; set; }
        public virtual BrandViewModel Brand { get; set; }
        public virtual List<ProductSizeViewModel> Sizes { get; set; }
        public virtual ProductTypeViewModel ProductType { get; set; }
        public decimal Price { get; set; }
        public bool IsSoldOut => Sizes.Any(p => p.Quantity == 0);
        public List<SuggestedProductViewModel> SuggestedProducts { get; set; }
        public AddToCartViewModel AddToCart { get; set; }
    }
}
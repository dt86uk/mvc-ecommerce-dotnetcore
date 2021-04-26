using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}

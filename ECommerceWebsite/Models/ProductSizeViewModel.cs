using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class ProductSizeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public bool IsSelected => false;
    }
}
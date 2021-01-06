using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class ProductItemViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
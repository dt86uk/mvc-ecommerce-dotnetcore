
namespace ECommerceWebsite.Models.Admin
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
    }
}
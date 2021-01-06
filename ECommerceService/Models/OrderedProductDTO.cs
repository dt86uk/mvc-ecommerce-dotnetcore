namespace ECommerceService.Models
{
    public class OrderedProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
    }
}

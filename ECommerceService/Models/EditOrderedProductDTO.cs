namespace ECommerceService.Models
{
    public class EditOrderedProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
    }
}
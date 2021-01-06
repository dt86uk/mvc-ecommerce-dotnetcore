namespace ECommerceService.Models
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FilePath { get; set; }
    }
}
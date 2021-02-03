namespace ECommerceService.Models
{
    public class ProductSizeDTO : EntityDTO
    {
        public override string Value => Size;
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
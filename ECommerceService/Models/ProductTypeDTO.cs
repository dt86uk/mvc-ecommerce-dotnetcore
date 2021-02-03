namespace ECommerceService.Models
{
    public class ProductTypeDTO : EntityDTO
    {
        public override string Value => ProductTypeName;
        public string ProductTypeName { get; set; }
    }
}
namespace ECommerceService.Models
{
    public class BrandDTO : EntityDTO
    {
        public override string Value => BrandName;
        public string BrandName { get; set; }
    }
}
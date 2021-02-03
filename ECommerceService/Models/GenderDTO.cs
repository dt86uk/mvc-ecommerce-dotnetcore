namespace ECommerceService.Models
{
    public class GenderDTO : EntityDTO
    {
        public override string Value => GenderName;
        public string GenderName { get; set; }
    }
}
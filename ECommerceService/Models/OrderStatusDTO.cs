namespace ECommerceService.Models
{
    public class OrderStatusDTO : EntityDTO
    {
        public override string Value => OrderStatus;
        public string OrderStatus { get; set; }
    }
}
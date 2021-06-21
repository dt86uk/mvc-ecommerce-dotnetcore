namespace ECommerceService.Models
{
    public class OrderInformationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Cost { get; set; }
        public bool PaymentReceived { get; set; }
    }
}
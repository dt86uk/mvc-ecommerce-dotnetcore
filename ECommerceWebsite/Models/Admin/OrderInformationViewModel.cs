namespace ECommerceWebsite.Models.Admin
{
    public class OrderInformationViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Cost { get; set; }
        public bool PaymentReceived { get; set; }
    }
}
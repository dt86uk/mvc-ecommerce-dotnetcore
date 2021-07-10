using System;
using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class EditOrderInformationDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public virtual List<EditOrderedProductDTO> OrderedProducts { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public DeliveryInformationDTO BillingInformation { get; set; }
        public DeliveryInformationDTO ShippingInformation { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool PaymentReceived { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
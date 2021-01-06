using System;
using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderedProducts = new List<OrderedProductDTO>();
            Customer = new UserDTO();
            PaymentDetails = new PaymentDetailDTO();
        }

        public int Id { get; set; }
        public List<OrderedProductDTO> OrderedProducts { get; set; }
        public string OrderStatus { get; set; }
        public UserDTO Customer { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ReferenceNumber { get; set; }
        public PaymentDetailDTO PaymentDetails { get; set; }
        public DeliveryInformationDTO ShippingInformation { get; set; }
        public DeliveryInformationDTO BillingInformation { get; set; }
        public bool PaymentProcessed { get; set; }
    }
}
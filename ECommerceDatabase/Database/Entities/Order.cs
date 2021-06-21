using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual List<OrderedProduct> OrderedProducts { get; set; }
        public string OrderStatus { get; set; }
        public DeliveryInformation ShippingInformation { get; set; }
        public DeliveryInformation BillingInformation { get; set; }
        public DateTime ArrivalDate => DateTime.Now.AddDays(14);
        public bool PaymentReceived { get; set; }
        public string ReferenceNumber { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }
        public virtual User Customer { get; set; }
    }
}
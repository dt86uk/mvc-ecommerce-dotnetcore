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
        
        [ForeignKey("Id")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual List<OrderedProduct> OrderedProducts { get; set; }

        [ForeignKey("Id")]
        public int BillingInformationId { get; set; }
        public virtual DeliveryInformation BillingInformation { get; set; }

        [ForeignKey("Id")]
        public int ShippingInformationId { get; set; }
        public virtual DeliveryInformation ShippingInformation { get; set; }

        public DateTime ArrivalDate => DateTime.Now.AddDays(14);
        public bool PaymentReceived { get; set; }
        public string ReferenceNumber { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }
        public virtual User Customer { get; set; }
    }
}
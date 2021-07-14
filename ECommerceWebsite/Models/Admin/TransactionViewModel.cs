using System;
using System.Linq;

namespace ECommerceWebsite.Models.Admin
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderViewModel Order { get; set; }
        public decimal TotalPrice => Order.Products.Sum(p => p.Price);
        public DeliveryInformationViewModel AddressDetails { get; set; }
    }
}
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Order Order { get; set; }
        public decimal TotalPrice => Order.OrderedProducts.Sum(p => p.Price);
        public virtual PaymentDetail PaymentDetails { get; set; }
        public virtual Address AddressDetails { get; set; }
    }
}
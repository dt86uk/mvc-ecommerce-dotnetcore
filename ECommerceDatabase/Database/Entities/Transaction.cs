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

        [ForeignKey("Id")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public decimal TotalPrice => Order.OrderedProducts.Sum(p => p.Price);

        [ForeignKey("Id")]
        public int PaymentDetailsId { get; set; }
        public virtual PaymentDetails PaymentDetails { get; set; }

        [ForeignKey("Id")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
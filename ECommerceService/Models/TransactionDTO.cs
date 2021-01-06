using System.Linq;

namespace ECommerceService.Models
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public virtual OrderDTO Order { get; set; }
        public decimal TotalPrice => Order.OrderedProducts.Sum(p => p.Price);
        public virtual PaymentDetailDTO PaymentDetails { get; set; }
        public virtual AddressDTO AddressDetails { get; set; }
    }
}

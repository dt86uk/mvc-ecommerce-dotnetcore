using System;

namespace ECommerceService.Models
{
    public class TransactionItemDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
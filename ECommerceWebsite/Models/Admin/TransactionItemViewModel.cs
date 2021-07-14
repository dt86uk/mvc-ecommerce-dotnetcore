using System;

namespace ECommerceWebsite.Models.Admin
{
    public class TransactionItemViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
using System;

namespace ECommerceService.Models
{
    public class LatestTransactionsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

using System;

namespace ECommerceWebsite.Models.Admin
{
    public class LatestTransactionsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
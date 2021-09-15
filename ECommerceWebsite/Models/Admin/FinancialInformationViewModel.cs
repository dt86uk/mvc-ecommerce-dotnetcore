using System;

namespace ECommerceWebsite.Models.Admin
{
    public class FinancialInformationViewModel
    {
        public int Id { get; set; }
        public decimal TotalTakings { get; set; }
        public DateTime Date { get; set; }
    }
}
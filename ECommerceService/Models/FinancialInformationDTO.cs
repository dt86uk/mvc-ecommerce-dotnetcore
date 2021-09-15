using System;

namespace ECommerceService.Models
{
    public class FinancialInformationDTO
    {
        public int Id { get; set; }
        public decimal TotalTakings { get; set; }
        public DateTime Date { get; set; }
    }
}
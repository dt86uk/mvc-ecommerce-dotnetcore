using System;
using System.Collections.Generic;

namespace ECommerceService.Models
{
    public class FinancialDetailsDTO
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public decimal Total { get; set; }        
        public List<OrderedProductDTO> ProductsSold { get; set; }
    }
}
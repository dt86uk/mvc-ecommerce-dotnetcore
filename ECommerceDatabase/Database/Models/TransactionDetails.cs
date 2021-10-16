using ECommerceDatabase.Database.Entities;
using System;
using System.Collections.Generic;

namespace ECommerceDatabase.Database.Models
{
    public class TransactionDetails
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderedProduct> ProductsSold { get; set; }
    }
}
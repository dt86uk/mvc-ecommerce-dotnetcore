using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminFinancialsDetailsItemViewModel
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public decimal Total { get; set; }
        public List<OrderedProductViewModel> ProductsSold { get; set; }
    }
}

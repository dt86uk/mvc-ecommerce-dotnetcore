using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceWebsite.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Products = new List<ProductItemViewModel>();
        }

        public string CartId { get; set; }

        public List<ProductItemViewModel> Products { get; set; }

        public int NumberOfItemsInCart => Products.Count();

        public decimal GrandTotal => Products.Sum(p => p.Price);

        public DateTime DateCreated => DateTime.Now;
    }
}
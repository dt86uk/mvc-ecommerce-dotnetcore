using System.Collections.Generic;
using System.Linq;

namespace ECommerceWebsite.Models
{
    public class CartSummaryViewModel : BaseViewModel
    {
        public CartSummaryViewModel()
        {
            Items = new List<CartSummaryItemViewModel>();
        }

        public List<CartSummaryItemViewModel> Items { get; set; }

        public int NumberOfItems => Items.Count;

        public decimal SubTotal => Items.Sum(p => p.Price);

        public decimal Delivery = 8.99m;
        public decimal GrandTotal => Items.Sum(p => p.Price) + Delivery;
    }
}

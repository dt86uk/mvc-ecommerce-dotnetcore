using System.Collections.Generic;

namespace ECommerceWebsite.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public virtual List<ProductViewModel> Products { get; set; }
        public string OrderStatus { get; set; }
        public virtual UserViewModel Customer { get; set; }
        public string ReferenceNumber { get;  set; }
    }
}

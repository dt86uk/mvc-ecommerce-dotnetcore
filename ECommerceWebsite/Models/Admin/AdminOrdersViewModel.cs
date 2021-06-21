using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminOrdersViewModel : AdminBaseViewModel
    {
        public List<OrderInformationViewModel> Orders { get; set; }
    }
}
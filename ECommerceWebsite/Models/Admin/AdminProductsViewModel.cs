using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminProductsViewModel : AdminBaseViewModel
    {
        public List<ProductsViewModel> AllProducts { get; set; }
    }
}
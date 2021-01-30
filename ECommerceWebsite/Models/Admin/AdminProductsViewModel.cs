using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminProductsViewModel : AdminBaseViewModel
    {
        public BaseWebServiceResponse ActionResponse { get; set; }
        public List<ProductsViewModel> AllProducts { get; set; }
    }
}
using System.Collections.Generic;

namespace ECommerceWebsite.Models
{
    public class CategoryProductsViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public List<CategoryProductItemViewMoel> Products { get; set; }
    }
}
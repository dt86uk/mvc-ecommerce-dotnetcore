using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminCategoriesViewModel : AdminBaseViewModel
    {
        public List<CategoryItemViewModel> Categories { get; set; }
    }
}
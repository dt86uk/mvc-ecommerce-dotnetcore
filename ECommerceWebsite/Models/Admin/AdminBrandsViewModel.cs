using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminBrandsViewModel : AdminBaseViewModel
    {
        public List<BrandsViewModel> AllBrands { get; set; }
    }
}
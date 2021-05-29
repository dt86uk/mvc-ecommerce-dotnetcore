using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminUsersViewModel : AdminBaseViewModel
    {
        public List<UsersViewModel> Users { get; set; }
    }
}
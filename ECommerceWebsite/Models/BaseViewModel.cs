using System.Collections.Generic;

namespace ECommerceWebsite.Models
{
    public class BaseViewModel
    { 
        public List<MenuItemViewModel> TopMenuItems { get; set; }
        public UserPanelViewModel Login { get; set; }
        public CartViewModel Cart { get; set; }
    }
}
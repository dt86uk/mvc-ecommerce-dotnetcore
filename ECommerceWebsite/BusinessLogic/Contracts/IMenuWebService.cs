using ECommerceWebsite.Models;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IMenuWebService
    {
        List<MenuItemViewModel> GetSubMenuItems();
        List<CarouselItemViewModel> GetHomeCarouselItems();
    }
}
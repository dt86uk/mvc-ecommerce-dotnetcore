using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// Queries the Repository and returns Data Transfer Objects (DTO) for the site Menu Items
    /// </summary>
    public interface IMenuService
    {
        List<CategoryDTO> GetSubMenuItems();
        List<ProductDTO> GetHomeCarouselItems();
    }
}
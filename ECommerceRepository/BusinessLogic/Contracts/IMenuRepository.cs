using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    /// <summary>
    /// Queries the database and returns the Entity Framework models for the site Menu Items
    /// </summary>
    public interface IMenuRepository
    {
        List<Category> GetSubMenuItems();
        List<Product> GetHomeCarouselItems();
    }
}
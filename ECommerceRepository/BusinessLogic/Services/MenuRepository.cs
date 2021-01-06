using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class MenuRepository : IMenuRepository
    {
        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetSubMenuItems()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Categories.ToList();
            }
        }

        /// <summary>
        /// Gets the items for the Carousel on the Home page.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetHomeCarouselItems()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.
                    Include("Images").
                    Where(p => p.Images.Any(c => c.FilePath.Contains("hero"))).ToList();
            }
        }
    }
}
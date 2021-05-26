using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Categories.Single(p => p.Id == categoryId);
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var categoryEntity = context.Categories.SingleOrDefault(p => p.Id == categoryId);

                if (categoryEntity != null)
                {
                    context.Entry(categoryEntity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.Categories.Remove(categoryEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool CategoryHasProducts(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.Any(p => p.CategoryId == categoryId);
            }
        }
    }
}
using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        bool Delete(int categoryId);
        bool CategoryHasProducts(int categoryId);
        bool CategoryExists(Category category);
        bool Update(Category category);
        bool Add(Category category);
    }
}
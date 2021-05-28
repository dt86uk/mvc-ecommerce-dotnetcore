using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(int categoryId);
        List<CategoryDTO> GetAllCategories();
        bool Delete(int categoryId);
        bool CategoryHasProducts(int categoryId);
        bool CategoryExists(CategoryDTO category);
        bool Update(CategoryDTO category);
        bool Add(CategoryDTO category);
    }
}
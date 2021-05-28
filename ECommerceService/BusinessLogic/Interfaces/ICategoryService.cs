using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(int categoryId);
        List<CategoryDTO> GetAllCategories();
        bool DeleteCategory(int categoryId);
        bool CategoryHasProducts(int categoryId);
        bool CategoryExists(CategoryDTO category);
        bool UpdateCategory(CategoryDTO category);
        bool AddCategory(CategoryDTO category);
    }
}
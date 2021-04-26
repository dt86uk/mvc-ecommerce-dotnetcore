using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(int categoryId);
        List<CategoryDTO> GetAllCategories();
    }
}
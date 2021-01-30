using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(int categoryId);
    }
}
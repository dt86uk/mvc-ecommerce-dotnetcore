using ECommerceService.BusinessLogic;

namespace ECommerceWebsite.BusinessLogic
{
    public class CategoryValidationService : ICategoryValidationService
    {
        private readonly ICategoryService _categoryService;
        public bool CategoryHasProducts(int categoryId)
        {
            return _categoryService.CategoryHasProducts(categoryId);
        }
    }
}
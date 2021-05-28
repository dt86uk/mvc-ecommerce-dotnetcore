using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface ICategoryWebService
    {
        AdminCategoriesViewModel GetAllCategories();
        BaseWebServiceResponse Delete(int categoryId);
        EditCategoryViewModel GetCategoryById(int categoryId);
        BaseWebServiceResponse Update(EditCategoryViewModel model);
        BaseWebServiceResponse Add(AddCategoryViewModel model);
    }
}
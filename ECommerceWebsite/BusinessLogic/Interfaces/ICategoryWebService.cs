using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    //TODO: Rename to CRUD: e.g. "Delete" => Not "DeleteCategory"
    public interface ICategoryWebService
    {
        AdminCategoriesViewModel GetAllCategories();
        BaseWebServiceResponse DeleteCategory(int categoryId);
        EditCategoryViewModel GetCategoryById(int categoryId);
        BaseWebServiceResponse UpdatedCategory(EditCategoryViewModel categoryId);
    }
}
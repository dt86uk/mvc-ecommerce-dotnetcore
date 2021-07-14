using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IBrandWebService
    {
        AdminBrandsViewModel GetAllBrands();
        BaseWebServiceResponse Add(AddBrandViewModel model);
        BaseWebServiceResponse Update(EditBrandViewModel model);
        BaseWebServiceResponse Delete(int brandId);
        EditBrandViewModel GetBrandById(int brandId);
    }
}
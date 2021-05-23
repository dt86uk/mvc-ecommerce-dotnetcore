using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IBrandWebService
    {
        AdminBrandsViewModel GetAllBrands();
        BaseWebServiceResponse AddBrand(AddBrandViewModel model);
        BaseWebServiceResponse UpdatedBrand(EditBrandViewModel model);
        BaseWebServiceResponse DeleteBrand(int brandId);
        EditBrandViewModel GetBrandById(int brandId);
    }
}
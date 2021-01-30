using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IBrandService
    {
        BrandDTO GetBrandById(int brandId);
    }
}
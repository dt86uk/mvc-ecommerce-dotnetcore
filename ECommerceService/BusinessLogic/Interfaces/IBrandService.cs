using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IBrandService
    {
        BrandDTO GetBrandById(int brandId);
        List<BrandDTO> GetAllBrands();
        bool Add(BrandDTO brand);
        bool Update(BrandDTO brand);
        bool BrandNameExists(BrandDTO brand);
        bool Delete(int brandId);
        bool BrandHasProducts(int brandId);
    }
}
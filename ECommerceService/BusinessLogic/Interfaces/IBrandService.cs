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
        bool BrandNameExists(string brandName);
        bool BrandNameExists(string brandName, int brandId);
        bool Delete(int brandId);
        bool BrandHasProducts(int brandId);
    }
}
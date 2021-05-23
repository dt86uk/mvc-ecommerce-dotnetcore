using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IBrandService
    {
        BrandDTO GetBrandById(int brandId);
        List<BrandDTO> GetAllBrands();
        bool AddBrand(BrandDTO brand);
        bool UpdateBrand(BrandDTO brand);
        bool BrandNameExists(string brandName);
        bool BrandNameExists(string brandName, int brandId);
        bool DeleteBrand(int brandId);
    }
}
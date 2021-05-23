using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
        bool BrandNameExists(string brandName);
        bool BrandNameExists(string brandName, int brandId);
        bool AddBrand(Brand brand);
        bool DeleteBrand(int brandId);
        bool UpdateBrand(Brand brand);
    }
}
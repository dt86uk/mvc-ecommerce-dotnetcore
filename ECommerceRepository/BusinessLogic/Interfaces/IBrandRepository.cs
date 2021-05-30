using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
        bool BrandNameExists(Brand brand);
        bool Add(Brand brand);
        bool Delete(int brandId);
        bool Update(Brand brand);
        bool BrandHasProducts(int brandId);
    }
}
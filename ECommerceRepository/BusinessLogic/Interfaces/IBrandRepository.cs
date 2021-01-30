using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
    }
}

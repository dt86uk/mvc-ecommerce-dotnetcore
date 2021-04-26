using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IBrandService
    {
        BrandDTO GetBrandById(int brandId);
        List<BrandDTO> GetAllBrands();
    }
}
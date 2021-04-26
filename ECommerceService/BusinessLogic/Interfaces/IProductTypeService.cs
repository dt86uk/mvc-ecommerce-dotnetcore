using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IProductTypeService
    {
        ProductTypeDTO GetProductTypeById(int productTypeId);
        List<ProductTypeDTO> GetAllProductTypes();
    }
}
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IProductTypeService
    {
        ProductTypeDTO GetProductTypeById(int productTypeId);
    }
}
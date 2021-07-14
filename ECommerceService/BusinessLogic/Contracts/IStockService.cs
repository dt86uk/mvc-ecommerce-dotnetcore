using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IStockService
    {
        bool IsStockAvailable(int productId, int sizeId);
        List<ProductStockDTO> GetFiveLowestStockProducts();
    }
}
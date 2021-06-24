using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface IProductSizeRepository
    {
        List<ProductSize> GetAllProductSizes();
        string GetSizeNameById(int sizeId);
    }
}
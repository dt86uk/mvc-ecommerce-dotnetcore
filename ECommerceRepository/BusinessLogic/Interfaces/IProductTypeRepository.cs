using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IProductTypeRepository
    {
        List<ProductType> GetAllProductTypes();
    }
}
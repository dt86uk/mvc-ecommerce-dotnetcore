using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IOrderedProductRepository
    {
        OrderedProduct GetOrderedProductById(int orderedProductId);
    }
}
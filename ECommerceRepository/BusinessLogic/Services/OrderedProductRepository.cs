using System.Linq;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class OrderedProductRepository : IOrderedProductRepository
    {
        public OrderedProduct GetOrderedProductById(int orderedProductId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.OrderedProducts.Single(p => p.Id == orderedProductId);
            }
        }
    }
}

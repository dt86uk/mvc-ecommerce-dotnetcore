using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        public List<ProductSize> GetAllProductSizes()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.ProductSizes.ToList();
            }
        }
    }
}
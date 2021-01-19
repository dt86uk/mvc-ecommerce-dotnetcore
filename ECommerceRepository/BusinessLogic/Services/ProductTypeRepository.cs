using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public List<ProductType> GetAllProductTypes()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.ProductTypes.ToList();
            }
        }
    }
}
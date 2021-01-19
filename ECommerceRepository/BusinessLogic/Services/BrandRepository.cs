using System.Collections.Generic;
using System.Linq;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class BrandRepository : IBrandRepository
    {
        public List<Brand> GetAllBrands()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Brands.ToList();
            }
        }
    }
}
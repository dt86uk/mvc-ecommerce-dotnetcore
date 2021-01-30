using System.Collections.Generic;

namespace ECommerceDatabase.Database.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
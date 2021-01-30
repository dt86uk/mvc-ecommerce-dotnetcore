using System.Collections.Generic;

namespace ECommerceDatabase.Database.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string ProductTypeName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
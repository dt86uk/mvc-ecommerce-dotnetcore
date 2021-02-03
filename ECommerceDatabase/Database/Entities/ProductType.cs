using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDatabase.Database.Entities
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
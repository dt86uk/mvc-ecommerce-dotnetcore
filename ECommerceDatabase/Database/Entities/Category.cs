using System.Collections.Generic;

namespace ECommerceDatabase.Database.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsGender => CategoryName != "New Releases";

        public virtual List<Product> Products { get; set; }
    }
}
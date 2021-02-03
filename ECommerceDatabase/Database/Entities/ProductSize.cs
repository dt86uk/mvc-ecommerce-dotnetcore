using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class ProductSize
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Id")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
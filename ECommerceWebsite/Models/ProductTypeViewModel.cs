using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class ProductTypeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
    }
}
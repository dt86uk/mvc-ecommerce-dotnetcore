using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Gender { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("Id")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Description { get; set; }
        public byte[] HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public virtual List<ProductImage> Images { get; set; }

        [ForeignKey("Id")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public int[] SizeIds { get; set; }

        public virtual List<ProductSize> Sizes { get; set; }


        [ForeignKey("Id")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
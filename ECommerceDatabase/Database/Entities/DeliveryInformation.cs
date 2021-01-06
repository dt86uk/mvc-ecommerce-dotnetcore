using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class DeliveryInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityTown { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string DeliveryMethod { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool TermsAndConditions { get; set; }
    }
}
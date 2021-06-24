using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class DeliveryInformationViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityTown { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string DeliveryMethod { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool TermsAndConditions { get; set; }
    }
}
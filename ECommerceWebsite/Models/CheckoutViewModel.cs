using System.ComponentModel.DataAnnotations;
namespace ECommerceWebsite.Models
{
    public class CheckoutViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "First Name required")]
        [Display(Name = "First Name")]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string ShippingLastName { get; set; }

        [Required(ErrorMessage = "Address Line 1 required")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        [Required(ErrorMessage = "City/Town required")]
        [Display(Name = "City/Town")]
        public string ShippingCityTown { get; set; }

        [Required(ErrorMessage = "Postal/Zip Code required")]
        [Display(Name = "Postal/Zip Code")]
        public string ShippingPostalCode { get; set; }

        [Required(ErrorMessage = "Country required")]
        [Display(Name = "Country")]
        public string ShippingCountry { get; set; }

        [Required]
        [Display(Name = "Delivery Method")]
        public string ShippingDeliveryMethod => "Standard";

        [Display(Name = "Phone")]
        [MinLength(7, ErrorMessage = "Phone number must be more than 7 digits long")]
        [Range(0, int.MaxValue, ErrorMessage = "Phone must be numbers")]
        public string ShippingPhone { get; set; }

        [Required(ErrorMessage = "Email required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Shipping Email format incorrect e.g. name@domain.com")]
        public string ShippingEmail { get; set; }

        [Required(ErrorMessage = "Terms & Conditions required")]
        [Display(Name = "Terms & Conditions")]
        public bool TermsAndConditions { get; set; }

        [Display(Name = "Does Billing Address match Shipping Address?")]
        public bool BillingIsShippingAddress { get; set; }

        [Display(Name = "First Name")]
        public string BillingFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string BillingLastName { get; set; }

        [Display(Name = "Address Line 1")]
        public string BillingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string BillingAddress2 { get; set; }

        [Display(Name = "City/Town")]
        public string BillingCityTown { get; set; }

        [Display(Name = "Postal/Zip Code")]
        public string BillingPostalCode { get; set; }

        [Display(Name = "Country")]
        public string BillingCountry { get; set; }

        [Display(Name = "Phone")]
        public string BillingPhone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Shipping Email format incorrect e.g. name@domain.com")]
        public string BillingEmail { get; set; }

        [Required(ErrorMessage = "Name on Card required")]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "Card Number required")]
        [MinLength(16, ErrorMessage = "Card Number is 16 digits")] //TODO : Make this CustomValidator
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiry Month")]
        [StringLength(2, ErrorMessage = "Expiry Month is 2 digits.")]
        public string ExpiryDateMonth { get; set; }
        
        [Required]
        [Display(Name = "Year")]
        [StringLength(2, ErrorMessage = "Expiry Year is 2 digits.")]
        public string ExpiryDateYear { get; set; }

        [Required]
        [MaxLength(3)]
        public string CCV { get; set; }
    }
}
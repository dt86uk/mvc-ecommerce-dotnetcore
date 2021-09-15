using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class TransactionViewModel : AdminBaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Created On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public OrderViewModel Order { get; set; }

        [Display(Name = "Total")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Address Details")]
        public DeliveryInformationViewModel AddressDetails { get; set; }
    }
}
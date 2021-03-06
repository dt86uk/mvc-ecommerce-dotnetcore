﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models.Admin
{
    public class EditOrderInformationViewModel : AdminBaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public UserViewModel User { get; set; }

        [Display(Name = "Ordered Products")]
        public List<OrderedProductViewModel> OrderedProducts { get; set; }

        public int OrderStatusId { get; set; }

        [Display(Name = "Order Status")]
        public List<SelectListItem> OrderStatuses { get; set; }

        [Required(ErrorMessage = "Category required")]
        public string SelectedOrderStatus { get; set; }

        [Display(Name = "Billing Information")]
        public DeliveryInformationViewModel BillingInformation { get; set; }

        [Display(Name = "Shipping Information")]
        public DeliveryInformationViewModel ShippingInformation { get; set; }

        [Display(Name = "Arrival Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Payment Received?")]
        public bool PaymentReceived { get; set; }

        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }
    }
}
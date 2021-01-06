namespace ECommerceWebsite.Models
{
    public class FilterOptionsViewModel
    {
        public string Brand { get; set; } // drop down
        public string Gender { get; set; } // slider
        public string ProductType { get; set; } // multi select
        public string Price { get; set; } // slider; min / max
    }
}

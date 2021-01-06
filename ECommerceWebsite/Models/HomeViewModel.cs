using System.Collections.Generic;

namespace ECommerceWebsite.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public List<CarouselItemViewModel> CarouselItems { get; set; }
    }
}
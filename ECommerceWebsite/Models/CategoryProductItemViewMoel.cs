namespace ECommerceWebsite.Models
{
    public class CategoryProductItemViewMoel : BaseViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageSrc { get; set; }
        public string BrandName { get; set; }
        public string Url { get; set; }
    }
}
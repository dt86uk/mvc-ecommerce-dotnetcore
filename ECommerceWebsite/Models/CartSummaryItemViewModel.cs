using ECommerceWebsite.Helpers;

namespace ECommerceWebsite.Models
{
    public class CartSummaryItemViewModel
    {
        public CartSummaryItemViewModel()
        {
            Size = new ProductSizeViewModel();     
        }

        public CartSummaryItemViewModel(ProductItemViewModel productItemViewModel, ProductViewModel productViewModel, ProductSizeViewModel productSizeViewModel)
        {
            Brand = productItemViewModel.Brand;
            Description = productViewModel.Description;
            Price = productViewModel.Price;
            ImageSrc = productViewModel.Images[0].ImageSrc;
            Title = productViewModel.Title;
            ProductId = productItemViewModel.ProductId;
            Gender = ProductHelper.GetGenderDescription(productViewModel.Gender);
            Size = new ProductSizeViewModel() { Id = productSizeViewModel.Id, Size = productSizeViewModel.Size, Quantity = productItemViewModel.Quantity };
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string ImageSrc { get; set; }
        public string Brand { get; set; }
        public ProductSizeViewModel Size { get; set; }
        public decimal Price { get; set; }
    }
}
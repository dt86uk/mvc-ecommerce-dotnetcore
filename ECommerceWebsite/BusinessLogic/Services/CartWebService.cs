using System.Linq;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public class CartWebService : ICartWebService
    {
        private readonly IProductWebService _productWebService;

        public CartWebService(IProductWebService productWebService)
        {
            _productWebService = productWebService;
        }

        public CartViewModel AddToCart(CartViewModel cartModel, AddToCartViewModel addToCartModel)
        {
            var cartProduct = cartModel.Products.SingleOrDefault(p => p.ProductId == addToCartModel.ProductId);
            var product = _productWebService.GetProductById(addToCartModel.ProductId);

            bool productQuantityUpdated = false;
            if (!_productWebService.ProductQuantityIsOk(addToCartModel.ProductId, addToCartModel.SizeId))
            {
                return null;
            }
            else 
            {
                productQuantityUpdated = _productWebService.ReduceProductQuantity(addToCartModel.ProductId, addToCartModel.SizeId, 1);
            }

            if (!productQuantityUpdated)
            {
                return null;
            }

            if (cartProduct == null)
            {
                //product not found in cart, add new
                cartModel.Products.Add(new ProductItemViewModel()
                {
                    ProductId = addToCartModel.ProductId,
                    Brand = product.Brand.BrandName,
                    Quantity = 1,
                    Size = product.Sizes.SingleOrDefault(p => p.Id == addToCartModel.SizeId).Size,
                    Price = product.Price
                });
            }
            else 
            {
                var size = product.Sizes.SingleOrDefault(p => p.Id == addToCartModel.SizeId);

                if (size == null)
                {
                    //product found but size not found, add new
                    cartModel.Products.Add(new ProductItemViewModel()
                    {
                        ProductId = addToCartModel.ProductId,
                        Brand = product.Brand.BrandName,
                        Quantity = 1,
                        Size = product.Sizes.SingleOrDefault(p => p.Id == addToCartModel.SizeId).Size,
                        Price = product.Price
                    });
                }
                else if (addToCartModel.SizeId == size.Id)
                { 
                    cartProduct.Quantity++;
                }
            }

            return cartModel;
        }

        public CartViewModel RemoveItemFromCart(CartViewModel cart, int productId, bool removeProduct = false)
        {
            var product = cart.Products.SingleOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return cart;
            }

            if (removeProduct || product.Quantity - 1 == 0)
            {
                cart.Products.Remove(cart.Products.SingleOrDefault(p => p.ProductId == productId));
            }
            else
            {
                product.Quantity--;
            }

            return cart;
        }

        public CartSummaryViewModel GetCartSummary(CartViewModel cart)
        {
            var model = new CartSummaryViewModel();

            foreach (var productItem in cart.Products)
            {
                var product = _productWebService.GetProductById(productItem.ProductId);
                var size = product.Sizes.Single(p => p.Size == productItem.Size);

                model.Items.Add(new CartSummaryItemViewModel(productItem, product, size));
            }

            return model;
        }
    }
}
using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public interface ICartWebService
    {
        CartViewModel AddToCart(CartViewModel cartModel, AddToCartViewModel addtoCartModel);
        CartViewModel RemoveItemFromCart(CartViewModel cart, int productId, bool removeProduct = false);
        CartSummaryViewModel GetCartSummary(CartViewModel cart);
    }
}
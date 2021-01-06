using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IOrderWebService
    {
        OrderSuccessfulViewModel PlaceOrder(CheckoutViewModel model);
    }
}
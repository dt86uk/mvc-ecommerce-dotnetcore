using Microsoft.AspNetCore.Mvc;
using ECommerceWebsite.Models;
using ECommerceWebsite.BusinessLogic;

namespace ECommerceWebsite.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly IMenuWebService _menuWebService;
        private readonly ICartWebService _cartWebService;
        private readonly IOrderWebService _orderWebService;

        public CheckoutController(ICartWebService cartWebService, IMenuWebService menuWebService, IOrderWebService orderWebService)
        {
            _cartWebService = cartWebService;
            _menuWebService = menuWebService;
            _orderWebService = orderWebService;
        }

        public IActionResult Index()
        {
            var model = new CheckoutViewModel
            {
                Cart = GetCart(),
                Login = new UserPanelViewModel { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null },
                TopMenuItems = _menuWebService.GetSubMenuItems()
            };
            return View(model);
        }

        public IActionResult Remove(int productId)
        {
            _cartWebService.RemoveItemFromCart(GetCart(),productId);
            return Redirect($"https://{HttpContext.Request.Host}cart");
        }

        public IActionResult OrderSuccessful(CheckoutViewModel model)
        {
            //TODO: Refactor this
            model.Cart = GetCart();
            model.TopMenuItems = _menuWebService.GetSubMenuItems();
            model.Login = new UserPanelViewModel { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };

            var orderSuccessfulModel = _orderWebService.PlaceOrder(model);
            orderSuccessfulModel.Cart = new CartViewModel();
            orderSuccessfulModel.TopMenuItems = _menuWebService.GetSubMenuItems();
            orderSuccessfulModel.Login = new UserPanelViewModel { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };

            return View("OrderSuccessful", orderSuccessfulModel);
        }
    }
}
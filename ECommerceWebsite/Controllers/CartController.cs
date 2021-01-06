using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartWebService _cartWebService;
        private readonly IMenuWebService _menuWebService;

        public CartController(ICartWebService cartWebService, IMenuWebService menuWebService)
        {
            _cartWebService = cartWebService;
            _menuWebService = menuWebService;
        }

        public IActionResult Index()
        {
            var model = _cartWebService.GetCartSummary(GetCart());
            model.Cart = GetCart();
            model.Login = new UserPanelViewModel() { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View(model);
        }

        public IActionResult IncreaseQuantity(int productId, int sizeId)
        {
            var cart = _cartWebService.AddToCart(GetCart(), new AddToCartViewModel() { ProductId = productId, SizeId = sizeId });
            UpdateCart(cart);

            var model = _cartWebService.GetCartSummary(cart);
            model.Cart = cart;
            model.Login = new UserPanelViewModel() { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View("Index", model);
        }

        public IActionResult DecreaseQuantity(int productId)
        {
            var cart = _cartWebService.RemoveItemFromCart(GetCart(), productId);
            UpdateCart(cart);

            var model = _cartWebService.GetCartSummary(cart);
            model.Cart = cart;
            model.Login = new UserPanelViewModel() { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View("Index", model);
        }

        public IActionResult RemoveProduct(int productId)
        {
            var cart = _cartWebService.RemoveItemFromCart(GetCart(), productId, true);
            UpdateCart(cart);

            var model = _cartWebService.GetCartSummary(cart);
            model.Cart = cart;
            model.Login = new UserPanelViewModel() { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View("Index", model);
        }
    }
}
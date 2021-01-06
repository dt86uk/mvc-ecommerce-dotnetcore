using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceWebsite.Extensions;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Controllers
{
    public class BaseController : Controller
    {
        public const string UserPanelSessionName = "UserPanelSession";
        public const string UserSessionName = "UserSession";
        public const string CartSessionName = "CartSession";

        public void BuildBaseModel(BaseViewModel baseViewModel)
        {
            baseViewModel.Cart = GetCart();
            baseViewModel.Login = new UserPanelViewModel 
            { 
                User = GetUserSession(), 
                IsUserLoggedIn = GetUserSession() != null 
            };
        }

        public UserPanelViewModel GetUserPanel()
        {
            var loginModel = HttpContext.Session.GetObject<UserPanelViewModel>(UserPanelSessionName);
            return loginModel != null ? loginModel : null;
        }

        public UserViewModel GetUserSession()
        {
            var userSession = HttpContext.Session.GetObject<UserViewModel>(UserSessionName);
            return userSession != null ? userSession : null;
        }

        public CartViewModel GetCart()
        {
            var cart = HttpContext.Session.GetObject<CartViewModel>(CartSessionName);
            return cart ?? new CartViewModel() { CartId = CartSessionName };
        }

        public void UpdateUserPanelSession(UserPanelViewModel userPanel)
        {
            HttpContext.Session.SetObject(UserPanelSessionName, userPanel);
        }

        public void UpdateUserSession(UserViewModel user)
        {
            HttpContext.Session.SetObject(UserSessionName, user);
        }

        public void UpdateCart(CartViewModel cart)
        {
            HttpContext.Session.SetObject(CartSessionName, cart);
        }
    }
}

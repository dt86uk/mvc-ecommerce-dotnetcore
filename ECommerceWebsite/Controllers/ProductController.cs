using System;
using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Helpers;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        private IMenuWebService _menuWebService;
        private IProductWebService _productWebService;
        private ICartWebService _cartWebService;

        public ProductController(IProductWebService productWebService, IMenuWebService menuWebService, ICartWebService cartWebService)
        {
            _productWebService = productWebService;
            _menuWebService = menuWebService;
            _cartWebService = cartWebService;
        }

        [HttpGet]
        [Route("{productName}")]
        public IActionResult Index(string productName)
        {
            var model = _productWebService.GetProductByProductName(productName);

            model.Cart = GetCart();
            model.Login = new UserPanelViewModel() { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null };
            model.TopMenuItems = _menuWebService.GetSubMenuItems();
            model.SuggestedProducts = _productWebService.GetSuggestedProducts(
                model.Login.User == null ? 
                0 : 
                model.Login.User.Id, HttpContext.Request.Host.ToString());

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(ProductViewModel model)
        {
            var updatedCart = _cartWebService.AddToCart(GetCart(), model.AddToCart);
            UpdateCart(updatedCart);

            var product = _productWebService.GetProductById(model.AddToCart.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            string productName = ProductHelper.BuildProductUrl(product.ProductName); 
        
            TempData["AddedToCart"] = true;
            return Redirect($"https://{HttpContext.Request.Host}{HttpContext.Request.Path}/{productName.ToLower()}");
        }
    }
}
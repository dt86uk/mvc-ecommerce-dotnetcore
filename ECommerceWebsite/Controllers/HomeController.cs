using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Http;
using ECommerceWebsite.BusinessLogic;

namespace ECommerceWebsite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMenuWebService _menuWebService;

        public HomeController(IMenuWebService menuWebService)
        {
            _menuWebService = menuWebService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                Cart = GetCart(),
                Login = new UserPanelViewModel { User = GetUserSession(), IsUserLoggedIn = GetUserSession() != null },
                TopMenuItems = _menuWebService.GetSubMenuItems(),
                CarouselItems = _menuWebService.GetHomeCarouselItems()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel()
            {
                TopMenuItems = _menuWebService.GetSubMenuItems()
            };
            BuildBaseModel(model);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
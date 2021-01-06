using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginWebService _loginService;
        private readonly IMenuWebService _menuWebService;

        public LoginController(ILoginWebService loginService, IMenuWebService menuWebService)
        {
            _loginService = loginService;
            _menuWebService = menuWebService;
        }

        public IActionResult Index()
        {
            var model = new LoginViewModel();
            BuildBaseModel(model);
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View(model);
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loggedInUser = _loginService.LoginUser(model.Email, model.Password);
            if (loggedInUser == null)
            {
                ModelState.AddModelError("LoginFailed", "Login attempt failed. Email or Password is incorrect.");
                return View(model);
            }
            else 
            {
                UpdateUserSession(loggedInUser);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
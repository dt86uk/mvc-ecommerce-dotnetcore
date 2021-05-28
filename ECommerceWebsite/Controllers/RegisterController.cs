using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IMenuWebService _menuWebService;
        private readonly IUserWebService _userWebService;
        
        public RegisterController(IMenuWebService menuWebService, IUserWebService userWebService)
        {
            _menuWebService = menuWebService;
            _userWebService = userWebService;
        }

        public IActionResult Index()
        {
            var model = new RegisterViewModel();
            BuildBaseModel(model);
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            if (model?.Login?.User != null)
            {
                RedirectToAction("Index", "Account");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            BuildBaseModel(model);
            model.TopMenuItems = _menuWebService.GetSubMenuItems();
            if (!ModelState.IsValid)
            {   
                return View("Index", model);
            }
            
            BaseWebServiceResponse response = _userWebService.Register(model);
            if (!response.ActionSuccessful) 
            {
                ModelState.AddModelError(response.Error.Name, response.Error.Message);
                return View("Index", model);
            }

            UpdateUserSession(JsonConvert.DeserializeObject<UserViewModel>(response.JsonResponseObject));

            BuildBaseModel(model);
            TempData["NewUser"] = "Your account has been created!";
            return RedirectToAction("Index", "Home");
        }
    }
}
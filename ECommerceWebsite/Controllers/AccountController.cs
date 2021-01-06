using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMenuWebService _menuWebService;
        private readonly IUserWebService _userWebService;

        public AccountController(IMenuWebService menuWebService, IUserWebService userWebService)
        {
            _menuWebService = menuWebService;
            _userWebService = userWebService;
        }

        public IActionResult Index()
        {
            var userSession = GetUserSession();
            var model = _userWebService.GetUserById(userSession.Id);
            model.TopMenuItems = _menuWebService.GetSubMenuItems();
            BuildBaseModel(model);

            if (model == null)
            {
                TempData["UserNotFound"] = "There are a problem retrieving your information. If this problem persists, please contact us.";
                RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult UpdateAccount(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userWebService.UpdateUser(model))
            {
                ModelState.AddModelError("Update", "There was a problem updating your details. Please, try again.");
                return View(model);
            }

            TempData["UserUpdated"] = "Your details were successfully updated!";
            return View(model);
        }
    }
}
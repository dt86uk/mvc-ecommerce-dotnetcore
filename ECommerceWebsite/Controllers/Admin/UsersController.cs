using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        private const string UsersViewFolder = "~/Views/admin/users";
        private const string UserActionName = "UserAction";

        private readonly IUserWebService _userWebService;

        public UsersController(IUserWebService userWebService)
        {
            _userWebService = userWebService;
        }

        public IActionResult Index()
        {
            AdminUsersViewModel model = _userWebService.GetAllUsers();
            return View($"{UsersViewFolder}/Index.cshtml", model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            AddUserViewModel model = _userWebService.GetAddUserModel();
            return View($"{UsersViewFolder}/Add.cshtml", model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _userWebService.GetAddUserModel();
                return View($"{UsersViewFolder}/Add.cshtml", model);
            }

            BaseWebServiceResponse response = _userWebService.AddUser(model);
            TempData[UserActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {   
                model.ActionResponse = response;
                return View($"{UsersViewFolder}/Add.cshtml", model);
            }

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        [Route("edit/{userId:int}")]
        public IActionResult Edit(int userId)
        {
            EditUserViewModel model = _userWebService.GetEditUserModel(userId);
            return View($"{UsersViewFolder}/Edit.cshtml", model);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _userWebService.GetEditUserModel(model.Id);
                return View($"{UsersViewFolder}/Edit.cshtml", model);
            }

            BaseWebServiceResponse response = _userWebService.UpdateUser(model);
            TempData[UserActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{UsersViewFolder}/Edit.cshtml", model);
            }

            return RedirectToAction("Index", "Users");
        }

        [Route("delete")]
        public IActionResult Delete(UsersViewModel model)
        {
            BaseWebServiceResponse response = _userWebService.DeleteUser(model.Id);
            TempData[UserActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{UsersViewFolder}/Index.cshtml", model);
            }            

            return RedirectToAction("Index", "Users");
        }
    }
}
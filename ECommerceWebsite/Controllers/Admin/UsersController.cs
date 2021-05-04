using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

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

            BaseWebServiceResponse response = _userWebService.CreateUser(model);

            if (!response.ActionSuccessful)
            {
                TempData[UserActionName] = response.Error.Message;
                model.ActionResponse = response;
                return View($"{UsersViewFolder}/Add.cshtml", model);
            }

            AdminUsersViewModel returnModel = _userWebService.GetAllUsers();
            returnModel.ActionResponse = response;

            TempData[UserActionName] = "User added successfully!";
            return LocalRedirect("~/admin/users");
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

            if (!response.ActionSuccessful)
            {
                TempData[UserActionName] = response.Error.Message;
                return View($"{UsersViewFolder}/Edit.cshtml", model);
            }

            AdminUsersViewModel returnModel = _userWebService.GetAllUsers();
            returnModel.ActionResponse = response;

            TempData[UserActionName] = "User successfully updated";
            return View($"{UsersViewFolder}/Index.cshtml", returnModel);
        }

        [Route("delete")]
        public IActionResult Delete(UsersViewModel model)
        {
            TempData[UserActionName] = _userWebService.DeleteUser(model.Id) ?
                    "User Deleted!" :
                    "There was a problem deleting the user!";

            return RedirectToAction("Index", "products");
        }
    }
}
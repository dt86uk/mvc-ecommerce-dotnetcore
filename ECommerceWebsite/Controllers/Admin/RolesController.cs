using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class RolesController : Controller
    {
        private const string RolesViewFolder = "~/Views/admin/roles";
        private const string RolesActionName = "RoleAction";

        private readonly IRoleWebService _roleWebService;

        public RolesController(IRoleWebService roleWebService)
        {
            _roleWebService = roleWebService;
        }

        public IActionResult Index()
        {
            AdminRolesViewModel model = _roleWebService.GetAllRoles();
            return View($"{RolesViewFolder}/Index.cshtml", model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View($"{RolesViewFolder}/Add.cshtml", new AddRoleViewModel());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRole(AddRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View($"{RolesViewFolder}/Add.cshtml", model);
            }

            BaseWebServiceResponse response = _roleWebService.Add(model);
            TempData[RolesActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                model.ActionResponse = response;
                return View($"{RolesViewFolder}/Add.cshtml", model);
            }

            return RedirectToAction("Index", "Roles");
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [Route("delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
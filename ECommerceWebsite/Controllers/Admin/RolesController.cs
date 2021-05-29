using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class RolesController : Controller
    {
        private const string RolesViewFolder = "~/Views/admin/roles";
        private const string RolesActionName = "RoleAction";

        private readonly IRoleWebService _roleWebService;

        public IActionResult Index()
        {
            AdminRolesViewModel model = _roleWebService.GetAllRoles();
            return View($"{RolesViewFolder}/Index.cshtml", model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
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
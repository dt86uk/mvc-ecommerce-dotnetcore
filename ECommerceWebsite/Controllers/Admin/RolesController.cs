using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class RolesController : Controller
    {
        private const string RolesViewFolder = "~/Views/admin/roles";

        public IActionResult Index()
        {
            return View($"{RolesViewFolder}/Index.cshtml");
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
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        private const string UsersViewFolder = "~/Views/admin/users";

        public IActionResult Index()
        {
            return View($"{UsersViewFolder}/Index.cshtml");
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("edit")]
        public IActionResult Eit()
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

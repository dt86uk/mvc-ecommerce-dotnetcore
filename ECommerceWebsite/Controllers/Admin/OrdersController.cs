using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class OrdersController : Controller
    {
        private const string OrdersViewFolder = "~/Views/admin/orders";

        public IActionResult Index()
        {
            return View($"{OrdersViewFolder}/Index.cshtml");
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
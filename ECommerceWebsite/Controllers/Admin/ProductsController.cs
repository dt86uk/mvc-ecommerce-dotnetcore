using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class ProductsController : Controller//BaseAdminController
    {
        private const string ProductsViewFolder = "~/Views/admin/products";

        public IActionResult Index()
        {
            return View($"{ProductsViewFolder}/Index.cshtml");
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
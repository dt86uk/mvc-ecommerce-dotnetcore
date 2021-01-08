using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class BrandsController : Controller
    {
        private const string BrandsViewFolder = "~/Views/admin/brands";

        public IActionResult Index()
        {
            return View($"{BrandsViewFolder}/Index.cshtml");
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
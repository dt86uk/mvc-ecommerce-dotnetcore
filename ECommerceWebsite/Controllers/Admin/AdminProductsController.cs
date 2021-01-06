using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminProductsController : Controller//BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
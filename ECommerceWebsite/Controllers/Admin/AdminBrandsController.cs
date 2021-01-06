using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminBrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
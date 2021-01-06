using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
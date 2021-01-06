using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

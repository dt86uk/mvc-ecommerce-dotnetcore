using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminOrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
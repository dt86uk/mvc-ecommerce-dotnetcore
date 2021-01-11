using ECommerceWebsite.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    //[Authorize]
    public class AdminController : BaseAdminController
    {
        private readonly IUserWebService _userWebService;
        private readonly IAdminDashboardWebService _adminDashboardWebService;

        public AdminController(IAdminDashboardWebService adminDashboardWebService, IUserWebService userWebService) : base(userWebService)
        {
            _userWebService = userWebService;
            _adminDashboardWebService = adminDashboardWebService;
        }

        public IActionResult Index()
        {
            var model = _adminDashboardWebService.GetDashboard();
            return View(model);
        }
    }
}
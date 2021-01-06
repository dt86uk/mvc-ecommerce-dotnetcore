using ECommerceWebsite.BusinessLogic;

namespace ECommerceWebsite.Controllers
{
    public class BaseAdminController : BaseController
    {
        private IUserWebService _userWebService;

        public BaseAdminController(IUserWebService userWebService)
        {
            _userWebService = userWebService;

            //var user = GetUserSession();

            //if (user == null)
            //{
            //    RedirectToAction("Index", "Home");
            //}

            //int userRole = _userWebService.GetRoleByUserId(user.Id);

            //if (userRole != 1)
            //{
            //    RedirectToAction("Index", "Home");
            //}
        }
    }
}
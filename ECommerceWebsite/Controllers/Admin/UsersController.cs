using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        private const string UsersViewFolder = "~/Views/admin/users";
        private readonly IUserWebService _userWebService;

        public UsersController(IUserWebService userWebService)
        {
            _userWebService = userWebService;
        }

        public IActionResult Index()
        {
            AdminUsersViewModel model = _userWebService.GetAllUsers();
            return View($"{UsersViewFolder}/Index.cshtml", model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            //TODO: Create AddModel
            return View($"{UsersViewFolder}/Add.cshtml");
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            //EditProductViewModel editModel = _productWebService.GetProductById(productModel);
            //return View($"{ProductsViewFolder}/Edit.cshtml", editModel);
            return View();
        }

        [Route("delete")]
        public IActionResult Delete()
        {
            //TempData["ProductAction"] = _productWebService.DeleteProduct(productModel.Id);
            //return RedirectToAction("Index", "products");
            return View();
        }
    }
}

using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class CategoriesController : Controller
    {
        private const string CategoriesViewFolder = "~/Views/admin/categories";
        private const string CategoryActionName = "CategoryAction";

        private readonly ICategoryWebService _categoryWebService;
        
        public CategoriesController(ICategoryWebService categoryWebService)
        {
            _categoryWebService = categoryWebService;
        }

        public IActionResult Index()
        {
            AdminCategoriesViewModel model = _categoryWebService.GetAllCategories();
            return View($"{CategoriesViewFolder}/Index.cshtml", model);
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
        public IActionResult Delete(CategoryItemViewModel model)
        {
            BaseWebServiceResponse response = _categoryWebService.DeleteCategory(model.Id);

            if (!response.ActionSuccessful)
            {
                TempData[CategoryActionName] = response.Error.Message;
                return View($"{CategoryActionName}/Index.cshtml", model);
            }
            TempData[CategoryActionName] = response;
            return RedirectToAction("Index", "Brands");
        }
    }
}
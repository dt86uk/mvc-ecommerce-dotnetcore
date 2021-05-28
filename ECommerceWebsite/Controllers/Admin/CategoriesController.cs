using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View($"{CategoriesViewFolder}/Add.cshtml", new AddCategoryViewModel());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View($"{CategoriesViewFolder}/Add.cshtml", model);
            }

            BaseWebServiceResponse response = _categoryWebService.AddCategory(model);
            TempData[CategoryActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                model.ActionResponse = response;
                return View($"{CategoriesViewFolder}/Add.cshtml", model);
            }

            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        [Route("edit/{categoryId:int}")]
        public IActionResult Edit(int categoryId)
        {
            EditCategoryViewModel model = _categoryWebService.GetCategoryById(categoryId);
            return View($"{CategoriesViewFolder}/Edit.cshtml", model);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _categoryWebService.GetCategoryById(model.Id);
                return View($"{CategoriesViewFolder}/Edit.cshtml", model);
            }

            BaseWebServiceResponse response = _categoryWebService.UpdatedCategory(model);
            TempData[CategoryActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{CategoriesViewFolder}/Index.cshtml", model);
            }

            return RedirectToAction("Index", "Brands");
        }

        [Route("delete")]
        public IActionResult Delete(CategoryItemViewModel model)
        {
            BaseWebServiceResponse response = _categoryWebService.DeleteCategory(model.Id);
            TempData[CategoryActionName] = response;

            if (!response.ActionSuccessful)
            {
                return View($"{CategoryActionName}/Index.cshtml", model);
            }

            return RedirectToAction("Index", "Categories");
        }
    }
}
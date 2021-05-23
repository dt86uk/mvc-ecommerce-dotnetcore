using Microsoft.AspNetCore.Mvc;
using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class ProductsController : Controller//BaseAdminController
    {
        private const string ProductsViewFolder = "~/Views/admin/products";
        private const string ProductActionName = "ProductAction";

        private readonly IProductWebService _productWebService;

        public ProductsController(IProductWebService productWebService)
        {
            _productWebService = productWebService;
        }

        public IActionResult Index()
        {
            AdminProductsViewModel model = _productWebService.GetAllProducts();
            return View($"{ProductsViewFolder}/Index.cshtml", model);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            AddProductViewModel model = _productWebService.GetAddProductsContent();
            return View($"{ProductsViewFolder}/Add.cshtml", model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _productWebService.GetAddProductsContent(model);
                return  View($"{ProductsViewFolder}/Add.cshtml", model);
            }

            BaseWebServiceResponse response = _productWebService.AddProduct(model);

            if (!response.ActionSuccessful)
            {
                TempData[ProductActionName] = response.Error.Message;
                model.ActionResponse = response;
                return View($"{ProductsViewFolder}/Add.cshtml", model);
            }

            TempData[ProductActionName] = response;
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        [Route("edit/{productId:int}")]
        public IActionResult Edit(int productId)
        {
            EditProductViewModel model = _productWebService.GetEditProductById(productId);
            return View($"{ProductsViewFolder}/Edit/{model.Id}", model);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _productWebService.GetEditProductById(model.Id);
                return View($"{ProductsViewFolder}/Edit/{model.Id}", model);
            }

            BaseWebServiceResponse response = _productWebService.UpdateProduct(model);

            if (!response.ActionSuccessful)
            {
                TempData[ProductActionName] = response.Error.Message;
                return View($"{ProductsViewFolder}/Edit.cshtml", model);
            }

            TempData[ProductActionName] = response;
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(ProductsViewModel model)
        {
            BaseWebServiceResponse response = _productWebService.DeleteProduct(model.Id);

            if (!response.ActionSuccessful)
            {
                TempData[ProductActionName] = response.Error.Message;
                return View($"{ProductsViewFolder}/Index.cshtml", model);
            }

            TempData[ProductActionName] = response;
            return RedirectToAction("Index", "products");
        }
    }
}
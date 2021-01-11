using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class ProductsController : Controller//BaseAdminController
    {
        private const string ProductsViewFolder = "~/Views/admin/products";

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

        [Route("add")]
        public IActionResult Add()
        {
            return View($"{ProductsViewFolder}/Index.cshtml");
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(ProductsViewModel productModel)
        {
            EditProductViewModel editModel = _productWebService.GetProductById(productModel);

            return View($"{ProductsViewFolder}/Edit.cshtml", editModel);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(ProductsViewModel productModel)
        {
            TempData["ProductDeleted"] = _productWebService.DeleteProduct(productModel.Id);
            return RedirectToAction("Index", "products");
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateProduct()
        {
            return View($"{ProductsViewFolder}/Index.cshtml");
        }
    }
}
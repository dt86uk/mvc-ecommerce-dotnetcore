using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

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
                TempData["ProductAction"] = response.Error.Message;
                return View($"{ProductsViewFolder}/Add.cshtml", model);
            }

            AdminProductsViewModel returnModel = _productWebService.GetAllProducts();
            returnModel.ActionResponse = response;

            //TODO: Url does not change/update to admin/products
            TempData["ProductAction"] = "Product added successfully!";
            return View($"{ProductsViewFolder}/Index.cshtml", returnModel);
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
            TempData["ProductAction"] = _productWebService.DeleteProduct(productModel.Id);
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
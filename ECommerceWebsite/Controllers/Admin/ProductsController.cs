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
            
            if (TempData["ProductAction"] != null)
            {
                model.ActionResponse = new BaseWebServiceResponse()
                {
                    ActionSuccessful = true
                };
            }

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
                model.ActionResponse = response;
                return View($"{ProductsViewFolder}/Add.cshtml", model);
            }

            AdminProductsViewModel returnModel = _productWebService.GetAllProducts();
            returnModel.ActionResponse = response;

            //TODO: Url does not change/update to admin/products
            TempData["ProductAction"] = "Product added successfully!";
            return View($"{ProductsViewFolder}/Index.cshtml", returnModel);
        }

        //TODO: Make all "edit" pages with e.g. site/area/id-here => Post puts all values in URL
        [HttpGet]
        [Route("edit/{productId:int}")]
        public IActionResult Edit(int productId)
        {
            EditProductViewModel editModel = _productWebService.GetEditProductById(productId);
            return View($"{ProductsViewFolder}/Edit.cshtml", editModel);
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
                TempData["ProductAction"] = response.Error.Message;
                return View($"{ProductsViewFolder}/Edit.cshtml", model);
            }

            TempData["ProductAction"] = "Product successfully updated";
            return LocalRedirect("~/admin/products");
        }


        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(ProductsViewModel productModel)
        {
            TempData["ProductAction"] = _productWebService.DeleteProduct(productModel.Id) ?
                    "Product Deleted!" :
                    "There was a problem deleting !";

            return RedirectToAction("Index", "products");
        }
    }
}
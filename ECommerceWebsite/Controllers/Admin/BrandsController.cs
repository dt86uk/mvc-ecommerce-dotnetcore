using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class BrandsController : Controller
    {
        private const string BrandsViewFolder = "~/Views/admin/brands";
        private const string BrandActionName = "BrandAction";

        private readonly IBrandWebService _brandWebService;

        public BrandsController(IBrandWebService brandWebService)
        {
            _brandWebService = brandWebService;
        }

        public IActionResult Index()
        {
            AdminBrandsViewModel model = _brandWebService.GetAllBrands();
            return View($"{BrandsViewFolder}/Index.cshtml", model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View($"{BrandsViewFolder}/Add.cshtml", new AddBrandViewModel());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddBrand(AddBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View($"{BrandsViewFolder}/Add.cshtml", model);
            }

            BaseWebServiceResponse response = _brandWebService.AddBrand(model);
            TempData[BrandActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                model.ActionResponse = response;
                return View($"{BrandsViewFolder}/Add.cshtml", model);
            }
            
            return RedirectToAction("Index", "Brands");
        }

        [HttpGet]
        [Route("edit/{brandId:int}")]
        public IActionResult Edit(int brandId)
        {
            EditBrandViewModel model = _brandWebService.GetBrandById(brandId);
            return View($"{BrandsViewFolder}/Edit.cshtml", model);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Update(EditBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _brandWebService.GetBrandById(model.Id);
                return View($"{BrandsViewFolder}/Edit.cshtml", model);
            }

            BaseWebServiceResponse response = _brandWebService.UpdatedBrand(model);
            TempData[BrandActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{BrandsViewFolder}/Index.cshtml", model);
            }

            return RedirectToAction("Index", "Brands");
        }

        [Route("delete")]
        public IActionResult Delete(BrandViewModel model)
        {
            BaseWebServiceResponse response = _brandWebService.DeleteBrand(model.Id);
            TempData[BrandActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{BrandsViewFolder}/Index.cshtml", model);
            }

            return RedirectToAction("Index", "Brands");
        }
    }
}
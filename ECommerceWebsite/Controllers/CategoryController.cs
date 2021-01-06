using ECommerceWebsite.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("category")]
    public class CategoryController : BaseController
    {
        private readonly IProductWebService _productWebService;
        private readonly IMenuWebService _menuWebService;

        public CategoryController(IProductWebService productWebService, IMenuWebService menuWebService)
        {
            _productWebService = productWebService;
            _menuWebService = menuWebService;
        }

        [HttpGet]
        [Route("{categoryName}")]
        public IActionResult Index(string categoryName)
        {
            //TODO: Move MenuWebSerbice to BaseController and Cache data to save on calls; check in WebService
            var model = _productWebService.GetProductsByCategoryName(categoryName, HttpContext.Request.Host.ToString());
            BuildBaseModel(model);
            model.TopMenuItems = _menuWebService.GetSubMenuItems();

            return View(model);
        }
    }
}
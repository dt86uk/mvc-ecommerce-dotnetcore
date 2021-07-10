using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class OrdersController : Controller
    {
        private const string OrdersViewFolder = "~/Views/admin/orders";
        private const string OrdersActionName = "OrdersAction";

        private readonly IOrdersManagementWebService _ordersManagementWebService;

        public OrdersController(IOrdersManagementWebService ordersManagementWebService)
        {
            _ordersManagementWebService = ordersManagementWebService;
        }

        public IActionResult Index()
        {
            AdminOrdersViewModel model = _ordersManagementWebService.GetOrders();
            return View($"{OrdersViewFolder}/Index.cshtml", model);
        }

        [HttpGet]
        [Route("edit/{orderId:int}")]
        public IActionResult Edit(int orderId)
        {
            EditOrderInformationViewModel model = _ordersManagementWebService.GetOrderById(orderId);
            return View($"{OrdersViewFolder}/Edit.cshtml", model);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Update(EditOrderInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _ordersManagementWebService.GetOrderById(model.Id);
                return View($"{OrdersViewFolder}/Edit.cshtml", model);
            }

            BaseWebServiceResponse response = _ordersManagementWebService.Update(model);
            TempData[OrdersActionName] = JsonConvert.SerializeObject(response);

            if (!response.ActionSuccessful)
            {
                return View($"{OrdersViewFolder}/Index.cshtml", model);
            }

            return RedirectToAction("Index", "orders");
        }
    }
}
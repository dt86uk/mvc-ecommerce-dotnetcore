using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Delete()
        {
            return View();
        }
    }
}
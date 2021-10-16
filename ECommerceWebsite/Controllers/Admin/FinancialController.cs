using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class FinancialController : Controller
    {
        private const string FinancialViewFolder = "~/Views/admin/financial";

        private readonly ITransactionWebService _transactionWebService;

        public FinancialController(ITransactionWebService transactionWebService)
        {
            _transactionWebService = transactionWebService;
        }

        public IActionResult Index()
        {
            AdminFinancialsViewModel model = _transactionWebService.GetFinancialsByCurrentMonth();
            return View($"{FinancialViewFolder}/Index.cshtml", model);
        }

        [Route("view/{date:datetime}")]
        public IActionResult View(DateTime date)
        {
            //AdminFinancialsViewModel model = _transactionWebService.GetFinancialsByDate(date);
            //return View($"{FinancialViewFolder}/Index.cshtml", model);

            return View();
        }
    }
}
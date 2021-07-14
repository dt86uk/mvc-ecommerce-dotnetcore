using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("admin/[controller]")]
    public class TransactionsController : Controller
    {
        private const string TransactionsViewFolder = "~/Views/admin/transactions";

        private readonly ITransactionWebService _transactionWebService;

        public TransactionsController(ITransactionWebService transactionWebService)
        {
            _transactionWebService = transactionWebService;
        }

        public IActionResult Index()
        {
            AdminTransactionsViewModel model = _transactionWebService.GetAllTransactions();
            return View($"{TransactionsViewFolder}/Index.cshtml", model);
        }


        [Route("view/{transactionId:int}")]
        public IActionResult View(int transactionId)
        {
            TransactionViewModel model = _transactionWebService.GetTransactionById(transactionId);
            return View($"{TransactionsViewFolder}/View.cshtml", model);
        }
    }
}
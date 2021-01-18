using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceWebsite.Controllers
{
    //[Authorize]
    public class AdminController : BaseAdminController
    {
        private readonly IUserWebService _userWebService;
        private readonly ISalesService _salesService;
        private readonly IStockService _stockService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public AdminController(ISalesService salesService, IStockService stockService, IUserWebService userWebService) : base(userWebService)
        {
            _salesService = salesService;
            _stockService = stockService;
            _userWebService = userWebService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public IActionResult Index()
        {
            var model = new AdminDashboardViewModel()
            {
                LatestTransactions = mapper.Map<List<LatestTransactionsDTO>, List<LatestTransactionsViewModel>>(_salesService.GetLatestTransactions()),
                FinancialInformation = mapper.Map<List<FinancialInformationDTO>, List<FinancialInformationViewModel>>(_salesService.GetDailyTakings(5)),
                LowStockProducts = mapper.Map<List<ProductStockDTO>, List<ProductStockViewModel>>(_stockService.GetFiveLowestStockProducts()),
                NewUsers = _userWebService.GetLatestNewUsers(5)
            };

            return View(model);
        }
    }
}
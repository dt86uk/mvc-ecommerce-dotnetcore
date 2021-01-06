using System.Collections.Generic;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class AdminDashboardWebService : IAdminDashboardWebService
    {
        private readonly IUserService _userService;
        private readonly ISalesService _salesService;
        private readonly IStockService _stockService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public AdminDashboardWebService(ISalesService salesService, IStockService stockService, IUserService userService)
        {
            _salesService = salesService;
            _stockService = stockService;
            _userService = userService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public AdminHomeViewModel GetDashboard()
        {
            return new AdminHomeViewModel()
            {
                LatestTransactions = mapper.Map<List<LatestTransactionsDTO>, List<LatestTransactionsViewModel>>(_salesService.GetLatestTransactions()),
                FinancialInformation = mapper.Map<List<FinancialInformationDTO>, List<FinancialInformationViewModel>>(_salesService.GetDailyTakings(5)),
                LowStockProducts = mapper.Map<List<ProductStockDTO>, List<ProductStockViewModel>>(_stockService.GetFiveLowestStockProducts()),
                NewUsers = mapper.Map<List<NewUserDTO>, List<NewUserViewModel>>(_userService.GetLatestNewUsers(5))
            };
        }
    }
}
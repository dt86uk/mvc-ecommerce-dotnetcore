using AutoMapper;
using System.Collections.Generic;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class OrdersManagementWebService : IOrdersManagementWebService
    {
        private readonly IOrdersManagementService _ordersManagementService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public OrdersManagementWebService(IOrdersManagementService ordersManagementService)
        {
            _ordersManagementService = ordersManagementService;

            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public AdminOrdersViewModel GetOrders()
        {
            var listOrders = mapper.Map<List<OrderInformationDTO>, List<OrderInformationViewModel>>(_ordersManagementService.GetOrders());

            return new AdminOrdersViewModel()
            {
                Orders = listOrders
            };
        }
    }
}
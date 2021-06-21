using System.Collections.Generic;
using AutoMapper;
using ECommerceService.Models;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceService.BusinessLogic
{
    public class OrdersManagementService : IOrdersManagementService
    {
        private readonly IOrdersManagementRepository _ordersManagementRepository;
        private readonly IUserService _userService;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public OrdersManagementService(IOrdersManagementRepository ordersManagementRepository, IUserService userService)
        {
            _ordersManagementRepository = ordersManagementRepository;
            _userService = userService;

            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public List<OrderInformationDTO> GetOrders()
        {
            var listOrdersInfoDto = mapper.Map<List<Order>, List<OrderInformationDTO>>(_ordersManagementRepository.GetOrders());

            foreach (var orderDto in listOrdersInfoDto)
            {
                var user = _userService.GetUserById(orderDto.UserId);
                orderDto.CustomerName = $"{user.FirstName} {user.LastName}";
            }

            return listOrdersInfoDto;
        }
    }
}
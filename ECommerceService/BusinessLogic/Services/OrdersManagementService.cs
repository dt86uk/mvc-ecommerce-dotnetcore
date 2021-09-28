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
        private readonly IOrderedProductRepository _orderedProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUserService _userService;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public OrdersManagementService(IOrdersManagementRepository ordersManagementRepository, IOrderedProductRepository orderedProductRepository, IProductRepository productRepository, IProductSizeRepository productSizeRepository, IUserService userService)
        {
            _ordersManagementRepository = ordersManagementRepository;
            _orderedProductRepository = orderedProductRepository;
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
            _userService = userService;

            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public List<OrderInformationDTO> GetOrders()
        {
            var listOrderEntities = _ordersManagementRepository.GetOrders();
            var listOrdersInfoDto = mapper.Map<List<Order>, List<OrderInformationDTO>>(listOrderEntities);

            foreach (var orderDto in listOrdersInfoDto)
            {
                var user = _userService.GetUserById(orderDto.UserId);
                orderDto.CustomerName = $"{user.FirstName} {user.LastName}";
            }

            return listOrdersInfoDto;
        }

        public EditOrderInformationDTO GetOrderById(int orderId)
        {
            var orderEntity = _ordersManagementRepository.GetOrderById(orderId);
            var model = mapper.Map<Order, EditOrderInformationDTO>(orderEntity);

            foreach (var orderedProductDto in model.OrderedProducts)
            {
                var orderedProduct = _orderedProductRepository.GetOrderedProductById(orderedProductDto.Id);
                orderedProductDto.Price = orderedProduct.Price;
                orderedProductDto.Product = _productRepository.GetProductNameById(orderedProduct.ProductId);
                orderedProductDto.Size = _productSizeRepository.GetSizeNameById(orderedProduct.SizeId);
            }

            return model;
        }

        public List<OrderStatusDTO> GetOrderStatuses()
        {
            var orderStatusEntity = _ordersManagementRepository.GetOrderStatuses();
            return mapper.Map<List<OrderStatus>, List<OrderStatusDTO>>(orderStatusEntity);
        }

        public bool Update(EditOrderInformationDTO order)
        {
            var orderEntity = mapper.Map<EditOrderInformationDTO, Order>(order);
            return _ordersManagementRepository.Update(orderEntity);
        }
    }
}
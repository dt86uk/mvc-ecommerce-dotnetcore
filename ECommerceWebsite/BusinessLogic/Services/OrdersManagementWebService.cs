using AutoMapper;
using System.Collections.Generic;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceWebsite.Helpers;
using System;
using ECommerceWebsite.Models;

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

        public EditOrderInformationViewModel GetOrderById(int orderId)
        {
            var model = mapper.Map<EditOrderInformationDTO, EditOrderInformationViewModel>(_ordersManagementService.GetOrderById(orderId));
            model.OrderStatuses = SelectListItemHelper.BuildDropDownList(_ordersManagementService.GetOrderStatuses());
            model.OrderStatuses.ForEach(p => p.Selected = int.Parse(p.Value) == model.OrderStatusId);

            return model;
        }

        public BaseWebServiceResponse Update(EditOrderInformationViewModel model)
        {
            var orderDto = mapper.Map<EditOrderInformationViewModel, EditOrderInformationDTO>(model);
            var orderUpdated = _ordersManagementService.Update(orderDto);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = orderUpdated,
                Error = orderUpdated ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Order",
                        Message = "There was a problem updating the Order. We have been notified of the error but please try again."
                    }
            };

            response.ActionSuccessful = true;
            response.SuccessMessage = "Order successfully updated";
            return response;
        }
    }
}
using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IOrdersManagementService
    {
        List<OrderInformationDTO> GetOrders();
        EditOrderInformationDTO GetOrderById(int orderId);
    }
}
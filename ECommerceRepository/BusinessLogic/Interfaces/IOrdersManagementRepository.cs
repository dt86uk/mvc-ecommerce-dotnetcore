using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IOrdersManagementRepository
    {
        List<Order> GetOrders();
        Order GetOrderById(int orderId);
    }
}
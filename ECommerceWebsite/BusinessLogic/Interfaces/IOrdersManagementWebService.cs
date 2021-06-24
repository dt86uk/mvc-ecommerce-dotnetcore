using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IOrdersManagementWebService
    {
        AdminOrdersViewModel GetOrders();
        EditOrderInformationViewModel GetOrderById(int orderId);
    }
}
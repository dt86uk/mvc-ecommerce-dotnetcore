using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// CRUD operations for Orders to the Repository and returns the Data Transfer Object (DTO) for Orders and Transactions
    /// </summary>
    public interface IOrderService
    {
        OrderDTO PlaceOrder(OrderDTO newOrder);
    }
}

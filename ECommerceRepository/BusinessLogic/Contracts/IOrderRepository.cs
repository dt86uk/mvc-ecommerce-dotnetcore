using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    /// <summary>
    /// CRUD operations for Orders with the database and returns the Entity Framework models for Orders and Transactions
    /// </summary>
    public interface IOrderRepository
    {
        Order PlaceOrder(Order newOrder);
    }
}

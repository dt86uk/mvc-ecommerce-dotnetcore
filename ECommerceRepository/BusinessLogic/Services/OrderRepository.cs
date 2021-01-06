using System;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Creates a Transaction with the new Order
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public Order PlaceOrder(Order newOrder)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                newOrder.Id = context.Orders.Add(newOrder).Entity.Id;
                newOrder.ReferenceNumber = Guid.NewGuid().ToString();
                context.SaveChanges();
                return newOrder;
            }
        }
    }
}
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class OrdersManagementRepository : IOrdersManagementRepository
    {
        public List<Order> GetOrders()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var listOrders = context.Orders
                    .Include("OrderedProducts")
                    .Include("Customer")
                    .ToList();

                return listOrders;
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var order = context.Orders
                    .Include("OrderedProducts")
                    .Include("Customer")
                    .Include("BillingInformation")
                    .Include("ShippingInformation")
                    .SingleOrDefault(p => p.Id == orderId);

                return order;
            }
        }
    }
}
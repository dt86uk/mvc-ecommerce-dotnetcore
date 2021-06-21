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
    }
}
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
                    .Include(p => p.OrderedProducts)
                    .Include(p => p.Customer)
                    .ToList();

                return listOrders;
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var order = context.Orders
                    .Include(p => p.OrderStatus)
                    .Include(p => p.OrderedProducts)
                    .Include(p => p.Customer)
                    .Include(p => p.BillingInformation)
                    .Include(p => p.ShippingInformation)
                    .SingleOrDefault(p => p.Id == orderId);

                return order;
            }
        }

        public List<OrderStatus> GetOrderStatuses()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.OrderStatuses.ToList();
            }
        }

        public bool Update(Order order)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var orderEntity = context.Orders
                    .Include(p => p.OrderStatus)
                    .Include(p => p.OrderedProducts)
                    .Include(p => p.Customer)
                    .Include(p => p.BillingInformation)
                    .Include(p => p.ShippingInformation)
                    .SingleOrDefault(p => p.Id == order.Id);

                if (orderEntity != null)
                {
                    orderEntity.OrderStatusId = order.OrderStatusId;

                    orderEntity.BillingInformation.FirstName = order.BillingInformation.FirstName;
                    orderEntity.BillingInformation.LastName = order.BillingInformation.LastName;
                    orderEntity.BillingInformation.Address1 = order.BillingInformation.Address1;
                    orderEntity.BillingInformation.Address2 = order.BillingInformation.Address2;
                    orderEntity.BillingInformation.CityTown = order.BillingInformation.CityTown;
                    orderEntity.BillingInformation.PostalCode = order.BillingInformation.PostalCode;
                    orderEntity.BillingInformation.Country = order.BillingInformation.Country;
                    orderEntity.BillingInformation.DeliveryMethod = order.BillingInformation.DeliveryMethod;
                    orderEntity.BillingInformation.Phone = order.BillingInformation.Phone;
                    orderEntity.BillingInformation.Email = order.BillingInformation.Email;

                    orderEntity.ShippingInformation.FirstName = order.ShippingInformation.FirstName;
                    orderEntity.ShippingInformation.LastName = order.ShippingInformation.LastName;
                    orderEntity.ShippingInformation.Address1 = order.ShippingInformation.Address1;
                    orderEntity.ShippingInformation.Address2 = order.ShippingInformation.Address2;
                    orderEntity.ShippingInformation.CityTown = order.ShippingInformation.CityTown;
                    orderEntity.ShippingInformation.PostalCode = order.ShippingInformation.PostalCode;
                    orderEntity.ShippingInformation.Country = order.ShippingInformation.Country;
                    orderEntity.ShippingInformation.DeliveryMethod = order.ShippingInformation.DeliveryMethod;
                    orderEntity.ShippingInformation.Phone = order.ShippingInformation.Phone;
                    orderEntity.ShippingInformation.Email = order.ShippingInformation.Email;

                    orderEntity.PaymentReceived = order.PaymentReceived;
                    orderEntity.ReferenceNumber = order.ReferenceNumber;

                    context.Entry(orderEntity).State = EntityState.Modified;
                    context.Orders.Update(orderEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase;

namespace TestsECommerceRepository.BusinessLogic
{
    [TestClass]
    public class OrderRepositoryTests
    {
        private OrderRepository orderRepository;
        private StartupDatabase database;

        [TestInitialize]
        public void Init()
        {
            database = new StartupDatabase();
            database.InitializeEFInMemoryDatabase(true);
            orderRepository = new OrderRepository();
        }

        [TestMethod]
        public void PlaceOrder()
        {
            //Arrange
            var order = new Order()
            {
                BillingInformation = new DeliveryInformation()
                {
                    Address1 = "1 Beehive Avenue",
                    Address2 = "Somewhere",
                    CityTown = "Wellington",
                    Country = "New Zealand",
                    DeliveryMethod = "Standard",
                    Email = "john.smith@domain.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "02112345678",
                    PostalCode = "6021",
                    TermsAndConditions = true
                },
                Customer = null,
                OrderedProducts = new List<OrderedProduct>()
                {
                    new OrderedProduct()
                    {
                        Price = 200.00m,
                        ProductId = 1,
                        SizeId = 1
                    }
                },
                OrderStatusId = 1,
                PaymentReceived = true,
                ReferenceNumber = string.Empty
            };
            order.ShippingInformation = order.BillingInformation;

            //Act
            var result = orderRepository.PlaceOrder(order);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(!string.IsNullOrEmpty(result.ReferenceNumber));
        }
    }
}
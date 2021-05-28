using System;
using System.Collections.Generic;
using ECommerceDatabase;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceRepository.BusinessLogic
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        private StartupDatabase database; 
        private TransactionRepository transactionRepository;

        [TestInitialize]
        public void Init()
        {
            database = new StartupDatabase();
            database.InitializeEFInMemoryDatabase(true);
            transactionRepository = new TransactionRepository();
        }

        [TestMethod]
        public void CreateTransaction()
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
                OrderStatus = "Ongoing",
                PaymentReceived = true,
                ReferenceNumber = string.Empty
            };
            order.ShippingInformation = order.BillingInformation;

            var transaction = new Transaction()
            {
                AddressDetails = new Address()
                {
                    Address1 = "1 Beehive Avenue",
                    Address2 = "Somewhere",
                    City = "Wellington",
                    PostCode = "6021",
                    Region = "Greater Wellington",
                    Country = "New Zealand",
                },
                Order = order,
                PaymentDetails = new PaymentDetail()
                {
                    NameOnCard = "Mr John Smith",
                    CardNumber = "483501234567",
                    CardType = "VISA",
                    ExpiryDateMonth = "08",
                    ExpiryDateYear = "24",
                    CCV = "140"
                }
            };

            //Act
            var result = transactionRepository.Create(transaction);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.AddressDetails);
            Assert.IsNotNull(result.Order);
            Assert.IsNotNull(result.PaymentDetails);
            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(result.TotalPrice > 0);
            Assert.IsTrue(result.Order.Id > 0);
            Assert.IsTrue(result.Order.ArrivalDate > DateTime.Now);
        }
    }
}
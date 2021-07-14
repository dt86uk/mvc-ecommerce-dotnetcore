using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using ECommerceDatabase.Database.Entities;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class TransactionServiceTests
    {
        private TransactionService _transactionService;
        private Mock<ITransactionRepository> _mockTransactionRepository;
        private Mock<IUserRepository> _mockUserRepository;

        [TestInitialize]
        public void Init()
        {
            _mockTransactionRepository = new Mock<ITransactionRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _transactionService = new TransactionService(_mockTransactionRepository.Object, _mockUserRepository.Object);
        }

        [TestMethod]
        public void CreateTransaction_IsSuccessful()
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

            var paymentDetail = new PaymentDetail()
            {
                NameOnCard = "Mr John Smith",
                CardNumber = "483501234567",
                CardType = "VISA",
                ExpiryDateMonth = "08",
                ExpiryDateYear = "24",
                CCV = "140"
            };

            var transaction = new Transaction()
            {
                Id = 1,
                Order = order,
                PaymentDetails = paymentDetail,
                AddressDetails = new Address()
                {
                    Address1 = "1 Beehive Avenue",
                    Address2 = "Somewhere",
                    City = "Wellington",
                    PostCode = "6021",
                    Region = "Greater Wellington",
                    Country = "New Zealand",
                }
            };

            _mockTransactionRepository
                .Setup(x => x.Create(It.IsAny<Transaction>()))
                .Returns(transaction);

            //Act
            var result = _transactionService.Create(order, paymentDetail);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 1);
            Assert.AreEqual(result.Order.BillingInformation.Address1, order.BillingInformation.Address1);
            Assert.AreEqual(result.Order.BillingInformation.Address2, order.BillingInformation.Address2);
            Assert.AreEqual(result.PaymentDetails.NameOnCard, paymentDetail.NameOnCard);
            Assert.AreEqual(result.PaymentDetails.CCV, paymentDetail.CCV);
        }
    }
}
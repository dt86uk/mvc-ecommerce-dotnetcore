using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceDatabase.Database.Entities;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService _orderService;
        private Mock<IStockService> _mockStockService;
        private Mock<ITransactionService> _mockTransactionService;

        [TestInitialize]
        public void Init()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _mockStockService = new Mock<IStockService>();

            _orderService = new OrderService(_mockTransactionService.Object, _mockStockService.Object);
        }

        [TestMethod]
        public void PlaceOrder_OrderIsSuccessful()
        {
            //Arrange
            var orderDto = new OrderDTO()
            {
                ArrivalDate = DateTime.Now.AddDays(14),
                BillingInformation = new DeliveryInformationDTO()
                {
                    Address1 = "1 Oxford Street",
                    Address2 = "Somewhere",
                    CityTown = "Wellington",
                    Country = "New Zealand",
                    DeliveryMethod = "Standard",
                    Email = "customer@email.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "02112345678",
                    PostCode = "6021"
                },
                OrderedProducts = new List<OrderedProductDTO>()
                {
                    new OrderedProductDTO()
                    {
                        Price = 200.00m,
                        ProductId = 1,
                        SizeId = 1
                    }
                },
                OrderStatus = "Ongoing",
                PaymentDetails = new PaymentDetailDTO()
                {
                    NameOnCard = "Mr Daniel Thornton",
                    ExpiryDateMonth = "08",
                    ExpiryDateYear = "2024",
                    CCV = "100",
                    CardNumber = "4385123456786789",
                    CardType = "VISA"
                }
            };
            orderDto.ShippingInformation = orderDto.BillingInformation;

            var returnedOrderDto = orderDto;
            returnedOrderDto.Id = 1;
            returnedOrderDto.PaymentProcessed = true;

            var transaction = new TransactionDTO()
            {
                Id = 1,
                Order = returnedOrderDto,
                AddressDetails = returnedOrderDto.ShippingInformation,
                PaymentDetails = returnedOrderDto.PaymentDetails
            };

            _mockStockService 
                .Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            _mockTransactionService
                .Setup(x => x.ProcessPayment(It.IsAny<PaymentDetail>()))
                .Returns(true);
            _mockTransactionService
                .Setup(x => x.Create(It.IsAny<Order>(), It.IsAny<PaymentDetail>()))
                .Returns(transaction);

            //Act
            var result = _orderService.PlaceOrder(orderDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual(result.ArrivalDate, orderDto.ArrivalDate);
            Assert.AreEqual(result.BillingInformation, orderDto.BillingInformation);
            Assert.AreEqual(result.ShippingInformation, orderDto.ShippingInformation);
            Assert.AreEqual(result.PaymentDetails, orderDto.PaymentDetails);
            Assert.AreEqual(result.OrderStatus, orderDto.OrderStatus);
            Assert.IsTrue(result.PaymentProcessed);
        }

        [TestMethod]
        public void PlaceOrder_StockNotAvailable()
        {
            //Arrange
            var orderDto = new OrderDTO()
            {
                ArrivalDate = DateTime.Now.AddDays(14),
                BillingInformation = new DeliveryInformationDTO()
                {
                    Address1 = "1 Oxford Street",
                    Address2 = "Somewhere",
                    CityTown = "Wellington",
                    Country = "New Zealand",
                    DeliveryMethod = "Standard",
                    Email = "customer@email.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "02112345678",
                    PostCode = "6021"
                },
                OrderedProducts = new List<OrderedProductDTO>()
                {
                    new OrderedProductDTO()
                    {
                        Price = 200.00m,
                        ProductId = 1,
                        SizeId = 1
                    }
                },
                OrderStatus = "Ongoing",
                PaymentDetails = new PaymentDetailDTO()
                {
                    NameOnCard = "Mr Daniel Thornton",
                    ExpiryDateMonth = "08",
                    ExpiryDateYear = "2024",
                    CCV = "100",
                    CardNumber = "4385123456786789",
                    CardType = "VISA"
                }
            };
            orderDto.ShippingInformation = orderDto.BillingInformation;

            _mockStockService
                .Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);

            //Act
            var result = _orderService.PlaceOrder(orderDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 0);
            Assert.IsFalse(result.PaymentProcessed);
        }

        [TestMethod]
        public void OrderPlace_ProcessPayment_Fails()
        {
            //Arrange
            var orderDto = new OrderDTO()
            {
                ArrivalDate = DateTime.Now.AddDays(14),
                BillingInformation = new DeliveryInformationDTO()
                {
                    Address1 = "1 Oxford Street",
                    Address2 = "Somewhere",
                    CityTown = "Wellington",
                    Country = "New Zealand",
                    DeliveryMethod = "Standard",
                    Email = "customer@email.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "02112345678",
                    PostCode = "6021"
                },
                OrderedProducts = new List<OrderedProductDTO>()
                {
                    new OrderedProductDTO()
                    {
                        Price = 200.00m,
                        ProductId = 1,
                        SizeId = 1
                    }
                },
                OrderStatus = "Ongoing",
                PaymentDetails = new PaymentDetailDTO()
                {
                    NameOnCard = "Mr Daniel Thornton",
                    ExpiryDateMonth = "08",
                    ExpiryDateYear = "2024",
                    CCV = "100",
                    CardNumber = "4385123456786789",
                    CardType = "VISA"
                }
            };
            orderDto.ShippingInformation = orderDto.BillingInformation;

            var transaction = new TransactionDTO()
            {
                Id = 1,
                Order = orderDto,
                AddressDetails = orderDto.ShippingInformation,
                PaymentDetails = orderDto.PaymentDetails
            };

            _mockStockService
                .Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            _mockTransactionService
                .Setup(x => x.ProcessPayment(It.IsAny<PaymentDetail>()))
                .Returns(false);
            
            _mockTransactionService
                .Setup(x => x.Create(It.IsAny<Order>(), It.IsAny<PaymentDetail>()))
                .Returns(transaction);

            //Act
            var result = _orderService.PlaceOrder(orderDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 0);
            Assert.IsFalse(result.PaymentProcessed);
        }
    }
}
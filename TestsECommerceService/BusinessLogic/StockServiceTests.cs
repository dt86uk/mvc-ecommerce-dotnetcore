using System.Collections.Generic;
using Moq;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class StockServiceTests
    {
        private StockService _stockService;
        private Mock<IProductRepository> _mockProductRepository;
        
        [TestInitialize]
        public void Init()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _stockService = new StockService(_mockProductRepository.Object);
        }

        [TestMethod]
        public void IsStockAvailable_IsAvailable()
        {
            //Arrange  
            int productId = 1;
            int sizeId = 1;
            var product = new Product()
            {
                Id = 1,
                Brand = new Brand()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                CategoryId = 1,
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductType()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSize>()
                {
                    new ProductSize()
                    {
                        Id = 1,
                        Quantity = 2,
                        Size = "US 8"
                    }
                },
                ProductName = "Product Title 1"
            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(product);

            //Act
            var result = _stockService.IsStockAvailable(productId, sizeId);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStockAvailable_StockNotAvailable()
        {
            //Arrange  
            int productId = 1;
            int sizeId = 1;
            var product = new Product()
            {
                Id = 1,
                Brand = new Brand()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                CategoryId = 1,
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductType()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSize>(),
                ProductName = "Product Title 1"
            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(product);

            //Act
            var result = _stockService.IsStockAvailable(productId, sizeId);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStockAvailable_StockNotFound()
        {
            //Arrange  
            int productId = 1;
            int sizeId = 12;
            var product = new Product()
            {
                Id = 1,
                Brand = new Brand()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                CategoryId = 1,
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductType()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSize>(),
                ProductName = "Product Title 1"
            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(product);

            //Act
            var result = _stockService.IsStockAvailable(productId, sizeId);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
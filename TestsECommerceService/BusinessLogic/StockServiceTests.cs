using System.Collections.Generic;
using Moq;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class StockServiceTests
    {
        private StockService _stockService;
        private Mock<IProductService> _mockProductService;
        
        [TestInitialize]
        public void Init()
        {
            _mockProductService = new Mock<IProductService>();
            _stockService = new StockService(_mockProductService.Object);
        }

        [TestMethod]
        public void IsStockAvailable_IsAvailable()
        {
            //Arrange  
            int productId = 1;
            int sizeId = 1;
            var productDto = new ProductDTO()
            {
                Id = 1,
                Brand = new BrandDTO()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                Category = new CategoryDTO()
                {
                    Id = 1,
                    CategoryName = "Men"
                },
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductTypeDTO()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSizeDTO>()
                {
                    new ProductSizeDTO()
                    {
                        Id = 1,
                        Quantity = 2,
                        Size = "US 8"
                    }
                },
                Title = "Product Title 1"
            };

            _mockProductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(productDto);

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
            var productDto = new ProductDTO()
            {
                Id = 1,
                Brand = new BrandDTO()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                Category = new CategoryDTO()
                {
                    Id = 1,
                    CategoryName = "Men"
                },
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductTypeDTO()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSizeDTO>(),
                Title = "Product Title 1"
            };

            _mockProductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(productDto);

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
            var productDto = new ProductDTO()
            {
                Id = 1,
                Brand = new BrandDTO()
                {
                    Id = 1,
                    BrandName = "Nike"
                },
                Category = new CategoryDTO()
                {
                    Id = 1,
                    CategoryName = "Men"
                },
                Description = "A description",
                Gender = "Men's",
                HeroTitle = "Hero Title",
                HeroImage = null,
                Images = null,
                Price = 200.00m,
                ProductType = new ProductTypeDTO()
                {
                    Id = 1,
                    ProductTypeName = "Shoes"
                },
                Sizes = new List<ProductSizeDTO>(),
                Title = "Product Title 1"
            };

            _mockProductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(productDto);

            //Act
            var result = _stockService.IsStockAvailable(productId, sizeId);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
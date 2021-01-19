using Moq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceService.Mapping;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class MenuServiceTests
    {
        private MenuService _menuService;
        private Mock<IMenuRepository> _mockMenuRepository;
        private IMapper mapper;
        private MapperConfiguration _config;

        [TestInitialize]
        public void Init()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _menuService = new MenuService(_mockMenuRepository.Object);
            _config = new AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        [TestMethod]
        public void HomeCarouselItems_ReturnsItems()
        {
            //Arrange
            var listProducts = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Brand = new Brand()
                    {
                        Id = 1,
                        BrandName = "Nike"
                    },
                    CategoryId = 1,
                    Description = "A description.",
                    Gender = "Male",
                    HeroImage = new byte[1],
                    HeroTitle = "Hero Title",
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
                    ProductName = "Nike Air Max"
                }
            };
            _mockMenuRepository
                .Setup(x => x.GetHomeCarouselItems())
                .Returns(listProducts);

            //Act
            var result = _menuService.GetHomeCarouselItems();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(result[0].Id, listProducts[0].Id);
            Assert.AreEqual(result[0].Brand.Id, listProducts[0].Brand.Id);
            Assert.AreEqual(result[0].Brand.BrandName, listProducts[0].Brand.BrandName);
            Assert.AreEqual(result[0].Category.Id, listProducts[0].CategoryId);
            Assert.AreEqual(result[0].Description, listProducts[0].Description);
            Assert.AreEqual(result[0].Gender, listProducts[0].Gender);
            Assert.AreEqual(result[0].HeroTitle, listProducts[0].HeroTitle);
            Assert.IsTrue(result[0].Images.Count == 0);
            Assert.AreEqual(result[0].Price, listProducts[0].Price);
            Assert.AreEqual(result[0].ProductType.Id, listProducts[0].ProductType.Id);
            Assert.AreEqual(result[0].ProductType.ProductTypeName, listProducts[0].ProductType.ProductTypeName);
            Assert.AreEqual(result[0].Sizes.Count, listProducts[0].Sizes.Count);
            Assert.AreEqual(result[0].ProductName, listProducts[0].ProductName);
        }

        [TestMethod]
        public void GetSubMenuItems_ReturnsItems()
        {
            //Arrange
            var listCategories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    CategoryName = "Shoes"
                }
            };
            _mockMenuRepository
                .Setup(x => x.GetSubMenuItems())
                .Returns(listCategories);

            //Act
            var result = _menuService.GetSubMenuItems();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<CategoryDTO>));
            Assert.IsTrue(result.Count == 1);
        }
    }
}
using System.Collections.Generic;
using Moq;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class ProductServiceTests
    {
        //ReduceProductQuantity test covered by Repository tests

        private ProductService _productService;
        private Mock<IProductRepository> _mockProductRepository;
        private List<Product> _listProducts;

        [TestInitialize]
        public void Init()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);

            _listProducts = new List<Product>()
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
                    Title = "Product Title 1"
                },
                new Product()
                {
                    Id = 2,
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
                    Price = 210.00m,
                    ProductType = new ProductType()
                    {
                        Id = 1,
                        ProductTypeName = "Shoes"
                    },
                    Sizes = new List<ProductSize>()
                    {
                        new ProductSize()
                        {
                            Id = 2,
                            Quantity = 2,
                            Size = "US 9"
                        }
                    },
                    Title = "Product Title 2"
                },
                new Product()
                {
                    Id = 3,
                    Brand = new Brand()
                    {
                        Id = 2,
                        BrandName = "Adidas"
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
                            Id = 3,
                            Quantity = 3,
                            Size = "US 10"
                        }
                    },
                    Title = "Product Title 3"
                }
            };
        }

        [TestMethod]
        public void GetProductById_ReturnsProduct()
        {
            //Arrange
            int productId = 1;
            var productEntity = new Product()
            {
                Id = productId,
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
                Title = "Product Title"
            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(productEntity);

            //Act
            var result = _productService.GetProductById(productId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, productEntity.Id);
            Assert.AreEqual(result.Brand.Id, productEntity.Brand.Id);
            Assert.AreEqual(result.Brand.BrandName, productEntity.Brand.BrandName);
            Assert.AreEqual(result.Category.Id, productEntity.CategoryId);
            Assert.AreEqual(result.Description, productEntity.Description);
            Assert.AreEqual(result.Gender, productEntity.Gender);
            Assert.AreEqual(result.Price, productEntity.Price);
            Assert.AreEqual(result.ProductType.Id, productEntity.ProductType.Id);
            Assert.AreEqual(result.ProductType.ProductTypeName, productEntity.ProductType.ProductTypeName);
            Assert.AreEqual(result.Sizes.Count, productEntity.Sizes.Count);
            Assert.AreEqual(result.Title, productEntity.Title);
        }

        [TestMethod]
        public void GetProductById_ReturnsNull()
        {
            //Arrange
            int productId = 1;
            
            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns((Product)null);

            //Act
            var result = _productService.GetProductById(productId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProductByProductName_ReturnsProduct()
        {
            //Arrange
            var productEntity = new Product()
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
                Title = "Product Title"
            };

            _mockProductRepository
                .Setup(x => x.GetProductByProductName(It.IsAny<string>()))
                .Returns(productEntity);

            //Act
            var result = _productService.GetProductByProductName(productEntity.Title);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, productEntity.Id);
            Assert.AreEqual(result.Brand.Id, productEntity.Brand.Id);
            Assert.AreEqual(result.Brand.BrandName, productEntity.Brand.BrandName);
            Assert.AreEqual(result.Category.Id, productEntity.CategoryId);
            Assert.AreEqual(result.Description, productEntity.Description);
            Assert.AreEqual(result.Gender, productEntity.Gender);
            Assert.AreEqual(result.Price, productEntity.Price);
            Assert.AreEqual(result.ProductType.Id, productEntity.ProductType.Id);
            Assert.AreEqual(result.ProductType.ProductTypeName, productEntity.ProductType.ProductTypeName);
            Assert.AreEqual(result.Sizes.Count, productEntity.Sizes.Count);
            Assert.AreEqual(result.Title, productEntity.Title);
        }

        [TestMethod]
        public void GetProductByProductName_ReturnsNull()
        {
            //Arrange
            var productEntity = new Product()
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
                Title = "Product Title"
            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns((Product)null);

            //Act
            var result = _productService.GetProductByProductName(productEntity.Title);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProductsByCategoryName_ReturnsProduct()
        {
            //Arrange
            var categoryName = "Men's";
            var listProduct = new List<Product>()
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
                    Title = "Product Title"
                }
            };

            _mockProductRepository
                .Setup(x => x.GetProductByCategoryName(It.IsAny<string>()))
                .Returns(listProduct);
                
            //Act
            var result = _productService.GetProductsByCategoryName(categoryName);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProductsByCategoryName_ReturnsEmptyObject()
        {
            //Arrange
            var categoryName = "Men's";
            _mockProductRepository
                .Setup(x => x.GetProductByCategoryName(It.IsAny<string>()))
                .Returns((List<Product>)null);

            //Act
            var result = _productService.GetProductsByCategoryName(categoryName);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count == 0);
        }

        [TestMethod]
        public void GetSuggestedProducts_UserId_ReturnsProducts()
        {
            //Arrange
            int userId = 1;
            _mockProductRepository
                .Setup(x => x.GetSuggestedProductsByUser(It.IsAny<int>()))
                .Returns(_listProducts)
                .Verifiable();

            //Act
            var result = _productService.GetSuggestedProducts(userId);

            //Assert
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.AreEqual(_listProducts[0].Brand.BrandName, result[0].Brand.BrandName);
            Assert.AreEqual(_listProducts[0].Description, result[0].Description);
            Assert.AreEqual(_listProducts[0].Price, result[0].Price);
            Assert.AreEqual(_listProducts[0].Title, result[0].Title);

            Assert.IsTrue(result[1].Id == 2);
            Assert.AreEqual(_listProducts[1].Brand.BrandName, result[1].Brand.BrandName);
            Assert.AreEqual(_listProducts[1].Description, result[1].Description);
            Assert.AreEqual(_listProducts[1].Price, result[1].Price);
            Assert.AreEqual(_listProducts[1].Title, result[1].Title);

            Assert.IsTrue(result[2].Id == 3);
            Assert.AreEqual(_listProducts[2].Brand.BrandName, result[2].Brand.BrandName);
            Assert.AreEqual(_listProducts[2].Description, result[2].Description);
            Assert.AreEqual(_listProducts[2].Price, result[2].Price);
            Assert.AreEqual(_listProducts[2].Title, result[2].Title);
                            
            _mockProductRepository.Verify(x => x.GetSuggestedProductsByUser(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetSuggestedProducts_NoUserId_ReturnsProducts()
        {
            //Arrange
            int userId = 0;
            _mockProductRepository
                .Setup(x => x.GetRandomProducts(It.IsAny<int>()))
                .Returns(_listProducts)
                .Verifiable();

            //Act
            var result = _productService.GetSuggestedProducts(userId);

            //Assert
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.AreEqual(_listProducts[0].Brand.BrandName, result[0].Brand.BrandName);
            Assert.AreEqual(_listProducts[0].Description, result[0].Description);
            Assert.AreEqual(_listProducts[0].Price, result[0].Price);
            Assert.AreEqual(_listProducts[0].Title, result[0].Title);

            Assert.IsTrue(result[1].Id == 2);
            Assert.AreEqual(_listProducts[1].Brand.BrandName, result[1].Brand.BrandName);
            Assert.AreEqual(_listProducts[1].Description, result[1].Description);
            Assert.AreEqual(_listProducts[1].Price, result[1].Price);
            Assert.AreEqual(_listProducts[1].Title, result[1].Title);

            Assert.IsTrue(result[2].Id == 3);
            Assert.AreEqual(_listProducts[2].Brand.BrandName, result[2].Brand.BrandName);
            Assert.AreEqual(_listProducts[2].Description, result[2].Description);
            Assert.AreEqual(_listProducts[2].Price, result[2].Price);
            Assert.AreEqual(_listProducts[2].Title, result[2].Title);

            _mockProductRepository.Verify(x => x.GetRandomProducts(It.IsAny<int>()));
        }
    }
}
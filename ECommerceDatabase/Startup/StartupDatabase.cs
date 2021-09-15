using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.EntityFramework;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.BusinessLogic;

namespace ECommerceDatabase
{
    /// <summary>
    /// Starts up Entity Framework In-Memory database with data.
    /// </summary>
    public class StartupDatabase
    {
        internal ECommerceContextDb context;

        private const string databaseName = "ECommerce";

        public void InitializeEFInMemoryDatabase()
        {
            using (context = new ECommerceContextDb(GetOptions()))
            {
                LoadData(context);
            }
        }

        /// <summary>
        /// If isUnitTest = true, this boots up the database without any products as it relies on file structure for images
        /// </summary>
        /// <param name="isUnitTest"></param>
        public void InitializeEFInMemoryDatabase(bool isUnitTest)
        {
            using (context = new ECommerceContextDb(GetOptions()))
            {
                LoadData(context, isUnitTest);
            }
        }

        public DbContextOptions<ECommerceContextDb> GetOptions()
        {
            return new DbContextOptionsBuilder<ECommerceContextDb>()
                   .UseInMemoryDatabase(databaseName: databaseName)
                   .Options;
        }

        internal bool LoadData(ECommerceContextDb context, bool isUnitTest = false)
        {
            try
            {
                if (context.Categories.Count() == 0)
                {
                    var listCategories = new List<Category>()
                    {
                        new Category { Id = 1, CategoryName = "New Releases" },
                        new Category { Id = 2, CategoryName = "Men" },
                        new Category { Id = 3, CategoryName = "Women" },
                        new Category { Id = 4, CategoryName = "Unisex" },
                        new Category { Id = 5, CategoryName = "Misc" },
                    };

                    listCategories.ForEach(p => context.Categories.Add(p));
                    context.SaveChanges();
                }

                if (context.Brands.Count() == 0)
                {
                    var listBrands = new List<Brand>()
                    {
                        new Brand { Id = 1, BrandName = "Nike" },
                        new Brand { Id = 2, BrandName = "Adidas" },
                        new Brand { Id = 3, BrandName = "Onnit" }
                    };

                    listBrands.ForEach(p => context.Brands.Add(p));
                    context.SaveChanges();
                }

                if (context.OrderStatuses.Count() == 0)
                {
                    var listOrderStatus = new List<OrderStatus>()
                    {
                        new OrderStatus { Id = 1, Status = "Ongoing" },
                        new OrderStatus { Id = 2, Status = "Completed" },
                        new OrderStatus { Id = 3, Status = "Abandoned" }
                    };

                    listOrderStatus.ForEach(p => context.OrderStatuses.Add(p));
                    context.SaveChanges();
                }

                if (context.ProductTypes.Count() == 0)
                {
                    var listProductType = new List<ProductType>()
                    {
                        new ProductType { Id = 1, ProductTypeName = "Shoes" },
                        new ProductType { Id = 2, ProductTypeName = "Headwear" },
                        new ProductType { Id = 3, ProductTypeName = "T-Shirts" }
                    };

                    listProductType.ForEach(p => context.ProductTypes.Add(p));
                    context.SaveChanges();
                }

                if (!isUnitTest)
                {
                    if (context.Products.Count() == 0)
                    {
                        var listProducts = new List<Product>()
                        {
                            new Product { Id = 1, Brand = context.Brands.SingleOrDefault(p => p.Id == 1), HeroImage = GetHeroImage(1), HeroTitle = "Nike Air Zoom Pegasus 37", ProductName = "Nike Air Zoom Pegasus 37", Description = GetDescription(1),
                                CategoryId = 1, Gender = GenderEnum.Male.ToString(), Sizes = GetProductSizes(1),
                                Images = GetImages(1), ProductType = context.ProductTypes.SingleOrDefault(p => p.Id == 1), SizeIds = new int[1], Price = 200 },
                            new Product { Id = 2, Brand = context.Brands.SingleOrDefault(p => p.Id == 1), HeroImage = GetHeroImage(2), HeroTitle = "Nike Mercurial Superfly 7 Elite MDS FG", ProductName = "Nike Mercurial Superfly 7 Elite MDS FG", Description = GetDescription(2),
                                CategoryId = 2, Gender = GenderEnum.Male.ToString(), Sizes = GetProductSizes(2),
                                Images = GetImages(2), ProductType = context.ProductTypes.SingleOrDefault(p => p.Id == 1), SizeIds = new int[2], Price = 370 },
                            new Product { Id = 3, Brand = context.Brands.SingleOrDefault(p => p.Id == 1), HeroImage = GetHeroImage(3), HeroTitle = "Nike Zoom Pegasus Turbo 2", ProductName = "Nike Zoom Pegasus Turbo 2", Description = GetDescription(3),
                                CategoryId = 3, Gender = GenderEnum.Male.ToString(), Sizes = GetProductSizes(3),
                                Images = GetImages(3), ProductType = context.ProductTypes.SingleOrDefault(p => p.Id == 1), SizeIds = new int[3], Price = 260 }
                        };

                        listProducts.ForEach(p => context.Products.Add(p));
                        context.SaveChanges();
                    }
                }

                if (context.Roles.Count() == 0)
                {
                    var listRoles = new List<Role>()
                    {
                        new Role { Id = 1, RoleName = "Administrator" },
                        new Role { Id = 2, RoleName = "SuperUser" },
                        new Role { Id = 3, RoleName = "User" }
                    };

                    listRoles.ForEach(p => context.Roles.Add(p));
                    context.SaveChanges();
                }

                var passwordEncryptionService = new PasswordEncryptionService();

                if (context.Users.Count() == 0)
                {
                    var listUsers = new List<User>()
                    {
                        new User { Id = 1, Email = "admin@ecommerce.com", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, FirstName = "Admin", LastName = "ECommerce", IsSubscribed = false, Password = passwordEncryptionService.SetPassword("thisisencrypted"), RoleId = 1 },
                        new User { Id = 2, Email = "superuser@ecommerce.com", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, FirstName = "Superuser", LastName = "ECommerce", IsSubscribed = false, Password = passwordEncryptionService.SetPassword("thisisencrypted"), RoleId = 2 },
                        new User { Id = 3, Email = "johnny.b.goode@somedomain.com", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, FirstName = "Johnny B.", LastName = "Goode", IsSubscribed = false, Password = passwordEncryptionService.SetPassword("thisisencrypted"), RoleId = 3 }
                    };

                    listUsers.ForEach(p => context.Users.Add(p));
                    context.SaveChanges();
                }

                if (context.BillingInformation.Count() == 0)
                {
                    var billingInformation = new DeliveryInformation()
                    {
                        Id = 1,
                        Address1 = "1 Purchase Way",
                        Address2 = "Moolah Town",
                        CityTown = "Dot upon Net",
                        Country = "United Kingdom",
                        DeliveryMethod = "VISA",
                        Email = "johnny.b.goode@somedomain.com",
                        FirstName = "Johnny B.",
                        LastName = "Goode",
                        Phone = "07512345678",
                        PostalCode = "NE13 6DR",
                        TermsAndConditions = true
                    };

                    context.BillingInformation.Add(billingInformation);
                    context.SaveChanges();
                }

                if (context.ShippingInformation.Count() == 0)
                {
                    var shippingInformation = new DeliveryInformation()
                    {
                        Id = 1,
                        Address1 = "1 Purchase Way",
                        Address2 = "Moolah Town",
                        CityTown = "Dot upon Net",
                        Country = "United Kingdom",
                        DeliveryMethod = "VISA",
                        Email = "johnny.b.goode@somedomain.com",
                        FirstName = "Johnny B.",
                        LastName = "Goode",
                        Phone = "07512345678",
                        PostalCode = "NE13 6DR",
                        TermsAndConditions = true
                    };

                    context.ShippingInformation.Add(shippingInformation);
                    context.SaveChanges();
                }

                if (context.Orders.Count() == 0)
                {
                    var order = new Order()
                    {
                        Id = 1,
                        OrderStatusId = 1,
                        BillingInformationId = 1,
                        ShippingInformationId = 1,
                        OrderedProducts = new List<OrderedProduct>()
                        {
                            new OrderedProduct()
                            {
                                Id = 1,
                                Price = 200,
                                ProductId = 1,
                                SizeId = 1
                            }
                        },
                        PaymentReceived = true,
                        ReferenceNumber = Guid.NewGuid().ToString(),
                        UserId = 3
                    };

                    context.Orders.Add(order);
                    context.SaveChanges();

                    var address = new Address()
                    {
                        Address1 = "1 Purchase Way",
                        Address2 = "Moolah Town",
                        CityTown = "Dot upon Net",
                        Country = "United Kingdom",
                        Region = "Tyne & Wear",
                        PostalCode = "NE13 6DR"
                    };

                    context.Addresses.Add(address);
                    context.SaveChanges();

                    var paymentDetails = new PaymentDetails()
                    {
                        NameOnCard = "Johnny B Goode",
                        CardNumber = "4835123456789876",
                        CardType = "VISA",
                        CCV = "123",
                        ExpiryDateMonth = DateTime.Now.Month.ToString().PadLeft(2, '0'),
                        ExpiryDateYear = DateTime.Now.Year.ToString("yy")
                    };

                    context.PaymentDetails.Add(paymentDetails);
                    context.SaveChanges();

                    var transaction = new Transaction()
                    {
                        OrderId = 1,
                        AddressId = 1,
                        CreatedDate = DateTime.Now,
                        PaymentDetailsId = 1
                    };

                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal List<ProductImage> GetImages(int productId)
        {
            var listProductImages = new List<ProductImage>();
            var filePaths = new List<string>();

            switch (productId)
            {
                case 1:
                    filePaths = Directory.GetFiles("Images/products/nike-air-zoom-pegasus-37/").ToList();
                    break;
                case 2:
                    filePaths = Directory.GetFiles("Images/products/nike-mercurial-superfly-7-elite-mds-fg/").ToList();
                    break;
                case 3:
                    filePaths = Directory.GetFiles("Images/products/nike-zoom-pegasus-turbo-2/").ToList();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                default:
                    throw new Exception("Product ID out of range.");
            }

            for (int i = 0; i < filePaths.Count; i++)
            {
                var count = context.ProductImages.Count();
                var id = count + i + 1000000;

                var productImage = context.ProductImages.Where(p => p.Id == id).SingleOrDefault();

                if (productImage == null)
                {
                    productImage = new ProductImage { Id = id, Image = File.ReadAllBytes(filePaths[i]), FilePath = filePaths[i].ToString() };
                    context.ProductImages.Add(productImage);
                    context.SaveChanges();
                }
                else
                {
                    productImage = new ProductImage { Id = id + 100, Image = File.ReadAllBytes(filePaths[i]), FilePath = filePaths[i].ToString() };
                    context.ProductImages.Add(productImage);
                    context.SaveChanges();
                }
                
                listProductImages.Add(productImage);
            }

            return listProductImages;
        }

        internal byte[] GetHeroImage(int productId)
        {
            var productImages = new ProductImage();
            var filePaths = new List<string>();

            switch (productId)
            {
                case 1:
                    filePaths = Directory.GetFiles("Images/products/nike-air-zoom-pegasus-37/").ToList();
                    break;
                case 2:
                    filePaths = Directory.GetFiles("Images/products/nike-mercurial-superfly-7-elite-mds-fg/").ToList();
                    break;
                case 3:
                    filePaths = Directory.GetFiles("Images/products/nike-zoom-pegasus-turbo-2/").ToList();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                default:
                    throw new Exception("Product ID out of range.");
            }

            for (int i = 0; i < filePaths.Count; i++)
            {
                if (filePaths[i].Contains("hero"))
                {
                    var id = context.ProductImages.Count() + i + 1;
                    var productImage = new ProductImage { 
                        Id = id, 
                        Image = File.ReadAllBytes(filePaths[i]),
                        FilePath = filePaths[i].ToString() };

                    context.ProductImages.Add(productImage);
                    context.SaveChanges();
                    break;
                }
            }

            return productImages.Image;
        }

        internal List<ProductSize> GetProductSizes(int productId)
        {
            var listProductTypes = new List<ProductSize>();

            switch (productId)
            {
                case 1:
                    listProductTypes.Add(new ProductSize { Id = 1, Size = "US 8", Quantity = 5, ProductId = 1,  });
                    listProductTypes.Add(new ProductSize { Id = 2, Size = "US 9", Quantity = 5, ProductId = 1 });
                    listProductTypes.Add(new ProductSize { Id = 3, Size = "US 10", Quantity = 5, ProductId = 1 });
                    break;
                case 2:
                    listProductTypes.Add(new ProductSize { Id = 9, Size = "US 6", Quantity = 8, ProductId = 2 });
                    listProductTypes.Add(new ProductSize { Id = 10, Size = "US 7", Quantity = 7, ProductId = 2 });
                    listProductTypes.Add(new ProductSize { Id = 11, Size = "US 8", Quantity = 3, ProductId = 2 });
                    listProductTypes.Add(new ProductSize { Id = 12, Size = "US 9", Quantity = 2, ProductId = 2 });
                    listProductTypes.Add(new ProductSize { Id = 13, Size = "US 10", Quantity = 1, ProductId = 2 });
                    break;
                case 3:
                    listProductTypes.Add(new ProductSize { Id = 4, Size = "US Men's 5 / Women's 7", Quantity = 5, ProductId = 3 });
                    listProductTypes.Add(new ProductSize { Id = 5, Size = "US Men's 6 / Women's 8", Quantity = 5, ProductId = 3 });
                    listProductTypes.Add(new ProductSize { Id = 6, Size = "US Men's 7 / Women's 9", Quantity = 5, ProductId = 3 });
                    listProductTypes.Add(new ProductSize { Id = 7, Size = "US Men's 8 / Women's 10", Quantity = 2, ProductId = 3 });
                    listProductTypes.Add(new ProductSize { Id = 8, Size = "US Men's 9 / Women's 11", Quantity = 0, ProductId = 3 });
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                default:
                    throw new Exception("Product ID out of range.");
            }

            return listProductTypes;
        }

        internal string GetDescription(int productId)
        {
            switch (productId)
            {
                case 1:
                    return "Reinvigorate your stride with the Nike Air Zoom Pegasus 37. Delivering the same fit and feel that runners love, the shoe has an all-new forefoot cushioning unit and foam for maximum responsiveness. The result is a durable, lightweight trainer designed for everyday running.";
                case 2:
                    return "Dream of speed and play fast in the Nike Mercurial Superfly 7 Elite MDS FG. A streamlined upper combines with a Nike Aerowtrac zone for high-speed play and supercharged traction.";
                case 3:
                    return "The Nike Zoom Pegasus Turbo 2 is updated with a feather-light upper, while innovative foam brings revolutionary responsiveness to your long-distance training.";
                case 4:
                    return string.Empty;
                case 5:
                    return string.Empty;
                case 6:
                    return string.Empty;
                case 7:
                    return string.Empty;
                case 8:
                    return string.Empty;
                case 9:
                    return string.Empty;
                default:
                    throw new Exception("Product ID out of range.");
            }
        }
    }
}
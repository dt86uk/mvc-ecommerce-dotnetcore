using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceDatabase;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase.BusinessLogic;
using ECommerceDatabase.Database.Entities;

namespace TestsECommerceRepository.BusinessLogic
{
    [TestClass]
    public class UserRepositoryTests
    {
        private StartupDatabase database;
        private UserRepository userRepository;
        private Mock<IPasswordEncryptionService> mockPasswordEncryptionService;

        [TestInitialize]
        public void Init()
        {
            database = new StartupDatabase();
            database.InitializeEFInMemoryDatabase(true);
            mockPasswordEncryptionService = new Mock<IPasswordEncryptionService>();
            userRepository = new UserRepository(mockPasswordEncryptionService.Object);
        }

        [TestMethod]
        public void CreateUser_UserAlreadyExists_ReturnsNull()
        {
            //Arrange
            var user = new User()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "admin@ecommerce.com",
                DateOfBirth = DateTime.Now.AddYears(-20),
                IsSubscribed = false,
                Password = "thisisencrypted",
                RoleId = 3
            };

            //Act
            var result = userRepository.CreateUser(user);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CreateUser_CreatesSuccessfully()
        {
            //Arrange
            string passwordToEncrypt = "thisisencrypted";
            var encryptedPassword = new PasswordEncryptionService().SetPassword(passwordToEncrypt);
            var user = new User()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@domain.com",
                DateOfBirth = DateTime.Now.AddYears(-20),
                IsSubscribed = false,
                Password = passwordToEncrypt,
                RoleId = 3
            };

            mockPasswordEncryptionService
                .Setup(p => p.SetPassword(user.Password))
                .Returns(encryptedPassword);

            //Act
            var result = userRepository.CreateUser(user);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(result.Email == user.Email);
            Assert.IsTrue(result.DateOfBirth == user.DateOfBirth);
            Assert.IsTrue(result.FirstName == user.FirstName);
            Assert.IsTrue(result.LastName == user.LastName);
            Assert.IsTrue(result.Password == user.Password);
            Assert.IsTrue(result.RoleId == user.RoleId);
        }
    }
}
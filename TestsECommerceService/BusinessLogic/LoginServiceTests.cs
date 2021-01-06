using System;
using Moq;
using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using ECommerceService.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class LoginServiceTests
    {
        private LoginService _loginService;
        private Mock<ILoginRepository> _mockLoginRespository;

        [TestInitialize]
        public void Init()
        {
            _mockLoginRespository = new Mock<ILoginRepository>();
            _loginService = new LoginService(_mockLoginRespository.Object);
        }

        [TestMethod]
        public void LoginUser_ReturnsNull()
        {
            //Arrange
            string email = "thisisnotanemail";
            string password = "password";
            _mockLoginRespository
                .Setup(x => x.LoginUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((User)null);

            //Act
            var result = _loginService.LoginUser(email, password);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoginUser_ReturnsUserDto()
        {
            //Arrange
            string email = "admin@ecommerce.com";
            string password = "thisisencrypted";
            var user = new User()
            {
                Id = 1,
                Email = email,
                DateOfBirth = DateTime.Now.AddYears(-18),
                FirstName = "John",
                LastName = "Smith",
                IsSubscribed = false,
                Password = password,
                RoleId = 1
            };

            _mockLoginRespository
                .Setup(x => x.LoginUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            //Act
            var result = _loginService.LoginUser(email, password);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, user.Id);
            Assert.AreEqual(result.Email, user.Email);
            Assert.AreEqual(result.DateOfBirth, user.DateOfBirth);
            Assert.AreEqual(result.FirstName, user.FirstName);
            Assert.AreEqual(result.LastName, user.LastName);
            Assert.AreEqual(result.IsSubscribed, user.IsSubscribed);
            Assert.AreEqual(result.Password, user.Password);
            Assert.AreEqual(result.RoleId, user.RoleId);
        }
    }
}
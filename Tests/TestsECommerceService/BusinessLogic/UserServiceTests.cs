using System;
using Moq;
using ECommerceRepository.BusinessLogic;
using ECommerceService.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceService.Models;
using ECommerceDatabase.Database.Entities;

namespace TestsECommerceService.BusinessLogic
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IRoleRepository> _mockRoleRepository;

        [TestInitialize]
        public void Init()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _userService = new UserService(_mockUserRepository.Object, _mockRoleRepository.Object);
        }

        [TestMethod]
        public void CreateUser_IsSuccessful()
        {
            //Arrange
            var userDto = new UserDTO()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@ecommerce.com",
                IsSubscribed = true,
                Password = "thisisencrypted",
                RoleId = 3,
                DateOfBirth = DateTime.Now.AddYears(-18)
            };
            
            var userEntity = new User()
            {
                Id = 100,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@ecommerce.com",
                IsSubscribed = true,
                Password = "thisisencrypted",
                RoleId = 3,
                DateOfBirth = DateTime.Now.AddYears(-18)
            };

            _mockUserRepository
                .Setup(x => x.Create(It.IsAny<User>()))
                .Returns(userEntity);

            //Act
            var result = _userService.Create(userDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, userEntity.Id);
            Assert.AreEqual(result.FirstName, userEntity.FirstName);
            Assert.AreEqual(result.LastName, userEntity.LastName);
            Assert.AreEqual(result.IsSubscribed, userEntity.IsSubscribed);
            Assert.AreEqual(result.RoleId, userEntity.RoleId);
            _mockUserRepository.Verify(x => x.Create(It.IsAny<User>()));
        }

        [TestMethod]
        public void GetUserById_ReturnsUser()
        {
            //Arrange
            int userId = 1;
            
            _mockUserRepository
                .Setup(x => x.GetUserById(It.IsAny<int>()))
                .Returns((User)null);

            //Act
            var result = _userService.GetUserById(userId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserById_ReturnsNull()
        {
            //Arrange
            int userId = 1;

            _mockUserRepository
                .Setup(x => x.GetUserById(It.IsAny<int>()))
                .Returns((User)null);

            //Act
            var result = _userService.GetUserById(userId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TryRollbackUser_DeleteUserIsCalled()
        {
            //Arrange
            var userEntity = new User()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "johnsmith@ecommerce.com",
                DateOfBirth = DateTime.Now.AddYears(-18),
                IsSubscribed = false,
                Password = "thisisencrypted",
                RoleId = 3
            };

            var userToDelete = new UserDTO()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "johnsmith@ecommerce.com",
                DateOfBirth = DateTime.Now.AddYears(-18),
                IsSubscribed = false,
                Password = "thisisencrypted",
                RoleId = 3,
            };
            
            _mockUserRepository
                .Setup(x => x.Create(It.IsAny<User>()))
                .Returns(userEntity);
            _mockUserRepository
                .Setup(x => x.Delete(It.IsAny<int>()));

            var newUser = _userService.Create(userToDelete);

            //Act
            _userService.TryRollbackUser(userToDelete);

            //Assert
            _mockUserRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }

        [TestMethod]
        public void TryRollbackUser_UserIsNull_DeleteUserNotCalled()
        {
            //Act
            _userService.TryRollbackUser(null);

            //Assert
            _mockUserRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
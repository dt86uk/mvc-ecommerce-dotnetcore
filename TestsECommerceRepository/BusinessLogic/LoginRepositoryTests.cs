using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceDatabase.BusinessLogic;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase;

namespace TestsECommerceRepository.BusinessLogic
{
    [TestClass]
    public class LoginRepositoryTests
    {
        private StartupDatabase database;
        private LoginRepository loginRepository;
        private Mock<IPasswordEncryptionService> mockPasswordEncryptionService;

        [TestInitialize]
        public void Init()
        {
            database = new StartupDatabase();
            database.InitializeEFInMemoryDatabase(true);
            mockPasswordEncryptionService = new Mock<IPasswordEncryptionService>();
            loginRepository = new LoginRepository(mockPasswordEncryptionService.Object);
        }

        [TestMethod]
        public void LoginUser_LoginIsSuccessful()
        {
            //Arrange
            string email = "admin@ecommerce.com";
            string password = "thisisencrypted";
            mockPasswordEncryptionService
                .Setup(p => p.Decrypt(It.IsAny<string>()))
                .Returns(password);

            //Act
            var result = loginRepository.LoginUser(email, password);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Email, email);
        }

        [TestMethod]
        public void LoginUser_LoginIsNotSuccessful_IncorrectEmail()
        {
            //Arrange
            string email = "fake@ecommerce.com";
            string password = "thisisencrypted";
            mockPasswordEncryptionService
                .Setup(p => p.Decrypt(It.IsAny<string>()))
                .Returns(password);

            //Act
            var result = loginRepository.LoginUser(email, password);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoginUser_LoginIsNotSuccessful_IncorrectPassword()
        {
            //Arrange
            string email = "admin@ecommerce.com";
            string incorrectPassword = "thisIsNotTheValidPassword";
            string correctPassword = "thisisencrypted";
            mockPasswordEncryptionService
                .Setup(p => p.Decrypt(It.IsAny<string>()))
                .Returns(correctPassword);

            //Act
            var result = loginRepository.LoginUser(email, incorrectPassword);

            //Assert
            Assert.IsNull(result);
        }
    }
}
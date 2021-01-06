using ECommerceDatabase.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceDatabase.BusinessLogic
{
    [TestClass]
    public class PasswordEncryptionServiceTests
    {
        private PasswordEncryptionService passwordEncryptionService;

        [TestInitialize]
        public void Init()
        {
             passwordEncryptionService = new PasswordEncryptionService();
        }

        [TestMethod]
        public void passwordEncryptionService_PasswordIsEncrypted()
        {
            //Arrange
            string password = "thisisencrypted";

            //Act
            var result = passwordEncryptionService.SetPassword(password);

            //Assert
            Assert.AreNotEqual(result, password);
        }

        [TestMethod]
        public void passwordEncryptionService_PasswordIsDecrypted()
        {
            //Arrange
            string password = "thisisencrypted";
            var encryptedPassword = passwordEncryptionService.SetPassword(password);

            //Act
            var decryptedPassword = passwordEncryptionService.Decrypt(encryptedPassword);

            //Assert
            Assert.AreEqual(decryptedPassword, password);
        }
    }
}
using System;
using System.Linq;
using ECommerceDatabase;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsECommerceDatabase
{
    [TestClass]
    public class StartupDatabaseTests
    {
        private StartupDatabase startupDatabase;

        [TestInitialize]
        public void Init()
        {
            startupDatabase = new StartupDatabase();
        }

        [TestMethod]
        public void StartupDatabase_StartsupTest()
        {
            //Arrange
            string email = "admin@ecommerce.com";

            //Act
            startupDatabase.InitializeEFInMemoryDatabase(true);
            User user = null;
            using (var context = new ECommerceContextDb(new StartupDatabase().GetOptions()))
            {
                user = context.Users.SingleOrDefault(p => string.Equals(p.Email, email, StringComparison.InvariantCultureIgnoreCase));
            }

            //Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(email, user.Email.ToLower());
        }
    }
}
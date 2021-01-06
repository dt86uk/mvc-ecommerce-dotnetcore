using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase;

namespace TestsECommerceRepository.BusinessLogic
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private StartupDatabase database;
        private MenuRepository menuRepository;

        [TestInitialize]
        public void Init()
        {
            database = new StartupDatabase();
            database.InitializeEFInMemoryDatabase(true);
            menuRepository = new MenuRepository();
        }

        [TestMethod]
        public void GetSubMenuItem_ReturnsItems()
        {
            //Act
            var result = menuRepository.GetSubMenuItems();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        //TODO: Put some images in a folder within this project so we can test this
        //[TestMethod]
        //public void GetHomeCarouselItemsTest()
        //{
        //    //Act
        //    var result = menuRepository.GetHomeCarouselItems();

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result.Count > 0);

        //    //Method gets Products whose Images contain 'hero' in the filename
        //    foreach (var item in result)
        //    {
        //        Assert.IsTrue(item.Images.Any(p => p.FilePath.Contains("hero")));
        //    }
        //}
    }
}

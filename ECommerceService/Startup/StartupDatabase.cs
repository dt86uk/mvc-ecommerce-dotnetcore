using Repository = ECommerceRepository;

namespace ECommerceService
{
    /// <summary>
    /// Allows the Database start-up to be initialized.
    /// </summary>
    public class StartupDatabase
    {
        public void InitializeEFInMemoryDatabase()
        {
            new Repository.StartupDatabase().InitializeEFInMemoryDatabase();
        }
    }
}
using Database = ECommerceDatabase;

namespace ECommerceRepository
{
    /// <summary>
    /// Allows the Database start-up to be initialized.
    /// </summary>
    public class StartupDatabase
    {
        public void InitializeEFInMemoryDatabase()
        {
            new Database.StartupDatabase().InitializeEFInMemoryDatabase();
        }
    }
}
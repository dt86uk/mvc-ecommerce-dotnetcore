namespace ECommerceDatabase.BusinessLogic
{
    public interface IPasswordEncryptionService
    {
        string SetPassword(string password);
        string Decrypt(string strData);
    }
}

using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface ILoginRepository
    {
        User LoginUser(string email, string password);
    }
}
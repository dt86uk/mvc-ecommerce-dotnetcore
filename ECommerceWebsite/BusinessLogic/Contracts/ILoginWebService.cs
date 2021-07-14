using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public interface ILoginWebService
    {
        UserViewModel LoginUser(string email, string password);
    }
}
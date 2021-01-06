using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserWebService
    {
        BaseUserWebServiceResponse CreateUser(RegisterViewModel model);
        AccountViewModel GetUserById(int userId);
        bool UpdateUser(AccountViewModel model);
        int GetRoleByUserId(int userId);
    }
}
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ILoginService
    {
        UserDTO LoginUser(string email, string password);
    }
}
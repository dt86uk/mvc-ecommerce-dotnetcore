using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IUserService
    {
        UserDTO CreateUser(UserDTO user);
        bool IsEmailInUse(string emailAddress);
        void TryRollbackUser(UserDTO newUser);
        UserDTO GetUserById(int userId);
        bool UpdateUser(UserDTO user);
        List<NewUserDTO> GetLatestNewUsers(int numberOfUsers);
        List<UserDetailsDTO> GetAllUsers();
    }
}
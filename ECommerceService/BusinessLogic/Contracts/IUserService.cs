using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IUserService
    {
        UserDTO Create(UserDTO user);
        bool IsEmailInUse(string emailAddress);
        void TryRollbackUser(UserDTO newUser);
        UserDTO GetUserById(int userId);
        bool Update(UserDTO user);
        List<NewUserDTO> GetLatestNewUsers(int numberOfUsers);
        List<UserDetailsDTO> GetAllUsers();
        List<RoleDTO> GetAllUserRoles();
        bool Delete(int userId);
    }
}
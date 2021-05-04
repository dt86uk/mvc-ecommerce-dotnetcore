using System.Collections.Generic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserWebService
    {
        BaseWebServiceResponse AddUser(AddUserViewModel model);
        BaseWebServiceResponse RegisterUser(RegisterViewModel model);
        AccountViewModel GetUserById(int userId);
        bool UpdateUser(AccountViewModel model);
        BaseWebServiceResponse UpdateUser(EditUserViewModel model);
        int GetRoleByUserId(int userId);
        List<NewUserViewModel> GetLatestNewUsers(int numberOfUsers);
        AdminUsersViewModel GetAllUsers();
        AddUserViewModel GetAddUserModel();
        bool DeleteUser(int userId);
        EditUserViewModel GetEditUserModel(int userId);
    }
}
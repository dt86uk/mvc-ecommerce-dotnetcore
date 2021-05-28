using System.Collections.Generic;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserWebService
    {
        BaseWebServiceResponse Add(AddUserViewModel model);
        BaseWebServiceResponse Register(RegisterViewModel model);
        AccountViewModel GetUserById(int userId);
        bool UpdateUser(AccountViewModel model);
        BaseWebServiceResponse Update(EditUserViewModel model);
        int GetRoleByUserId(int userId);
        List<NewUserViewModel> GetLatestNewUsers(int numberOfUsers);
        AdminUsersViewModel GetAllUsers();
        AddUserViewModel GetAddUserModel();
        BaseWebServiceResponse Delete(int userId);
        EditUserViewModel GetEditUserModel(int userId);
    }
}
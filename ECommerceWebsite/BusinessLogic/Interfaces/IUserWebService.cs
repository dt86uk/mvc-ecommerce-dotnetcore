using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserWebService
    {
        BaseWebServiceResponse CreateUser(RegisterViewModel model); //TODO: Review this, rename & repurpose for logic?
        AccountViewModel GetUserById(int userId);
        bool UpdateUser(AccountViewModel model);
        int GetRoleByUserId(int userId);
        List<NewUserViewModel> GetLatestNewUsers(int numberOfUsers);
        AdminUsersViewModel GetAllUsers();
        AddUserViewModel GetAddUserModel();
    }
}
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public interface IUserRepository
    {
        User Create(User user);
        bool IsEmailInUse(string emailAddress);
        bool Delete(int userId);
        User GetUserById(int userId);
        bool Update(User user);
        List<User> GetLatestNewUsers(int numberOfUsers);
        List<User> GetAllUsers();
    }
}
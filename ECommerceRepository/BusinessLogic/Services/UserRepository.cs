using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDatabase.BusinessLogic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class UserRepository : IUserRepository
    {
        private IPasswordEncryptionService _passwordEncryptionService;

        public UserRepository(IPasswordEncryptionService passwordEncryptionService)
        {
            _passwordEncryptionService = passwordEncryptionService;
        }

        public User CreateUser(User user)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                if (context.Users.Any(p => string.Equals(p.Email, user.Email, StringComparison.InvariantCultureIgnoreCase)))
                {
                    //a user with this email exists
                    return null;
                }

                user.Password = _passwordEncryptionService.SetPassword(user.Password);
                var createdUser = context.Users.Add(user).Entity;
                context.SaveChanges();

                return context.Users.Single(p => p.Id == createdUser.Id);
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var user = context.Users.SingleOrDefault(p => p.Id == userId);

                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public bool IsEmailInUse(string emailAddress)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Users.Any(p => string.Equals(p.Email, emailAddress, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Users.SingleOrDefault(p => p.Id == userId);
            }
        }

        public bool UpdateUser(User user)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var userEntity = context.Users.SingleOrDefault(p => string.Equals(p.Email, user.Email, StringComparison.InvariantCultureIgnoreCase));

                if (userEntity != null)
                {
                    userEntity.FirstName = user.FirstName;
                    userEntity.LastName = user.LastName;
                    userEntity.DateOfBirth = user.DateOfBirth;
                    userEntity.IsSubscribed = user.IsSubscribed;
                    userEntity.Email = user.Email;

                    context.Users.Update(userEntity);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<User> GetLatestNewUsers(int numberOfUsers)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var startDate = DateTime.Now.AddDays(-7);
                var endDate = DateTime.Now;

                return context.Users
                    .Where(p => p.CreatedDate >= startDate && p.CreatedDate <= endDate)
                    .Take(numberOfUsers).ToList();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Users.ToList();
            }
        }
    }
}
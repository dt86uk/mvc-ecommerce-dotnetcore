using System;
using System.Linq;
using ECommerceDatabase.BusinessLogic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IPasswordEncryptionService _passwordEncryptionService;

        public LoginRepository(IPasswordEncryptionService passwordEncryptionService)
        {
            _passwordEncryptionService = passwordEncryptionService;
        }

        public User LoginUser(string email, string password)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var userEntity = context.Users.SingleOrDefault(p => string.Equals(p.Email, email, StringComparison.InvariantCultureIgnoreCase));

                if (userEntity == null)
                {
                    return null;
                }

                var passwordDecrypted = _passwordEncryptionService.Decrypt(userEntity.Password);

                if (password == passwordDecrypted)
                {
                    return userEntity;
                }
                else 
                {
                    return null;
                }
            }
        }
    }
}
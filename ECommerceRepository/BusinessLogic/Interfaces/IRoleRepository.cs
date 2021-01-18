using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
    }
}
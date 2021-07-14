using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface IRoleRepository
    {
        Role GetRoleById(int roleId);
        List<Role> GetAllRoles();
        bool RoleNameExists(Role role);
        bool Add(Role role);
        bool Update(Role role);
        bool Delete(int roleId);
        bool RoleHasUsers(int roleId);
    }
}
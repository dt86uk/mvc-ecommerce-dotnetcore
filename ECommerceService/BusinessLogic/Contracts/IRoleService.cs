using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface IRoleService
    {
        RoleDTO GetRoleById(int roleId);
        List<RoleDTO> GetAllRoles();
        bool RoleNameExists(RoleDTO role);
        bool Add(RoleDTO role);
        bool Update(RoleDTO role);
        bool Delete(int roleId);
        bool RoleHasUsers(int roleId);
    }
}
using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
    }
}
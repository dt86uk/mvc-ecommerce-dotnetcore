using System.Linq;
using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.Helpers
{
    public static class UserHelper
    {
        public static List<UserDetailsDTO> AssignRolesToUsers(List<UserDetailsDTO> listUsersDetails, List<RoleDTO> listRoles)
        {
            foreach (var user in listUsersDetails)
            {
                var roleEntity = listRoles.SingleOrDefault(p => p.Id == user.RoleId);
                user.RoleName = roleEntity != null ? roleEntity.RoleName : string.Empty;
            }

            return listUsersDetails;
        }
    }
}

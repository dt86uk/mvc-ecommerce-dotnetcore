using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IRoleWebService
    {
        AdminRolesViewModel GetAllRoles();
    }
}
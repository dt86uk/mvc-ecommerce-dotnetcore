using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IRoleWebService
    {
        AdminRolesViewModel GetAllRoles();
        BaseWebServiceResponse Add(AddRoleViewModel model);
        BaseWebServiceResponse Update(EditRoleViewModel model);
        BaseWebServiceResponse Delete(int roleId);
        EditRoleViewModel GetRoleById(int roleId);
    }
}
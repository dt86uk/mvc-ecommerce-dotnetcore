using System.Collections.Generic;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class RoleWebService : IRoleWebService
    {
        private readonly IRoleService _roleService;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public RoleWebService(IRoleService roleService)
        {
            _roleService = roleService;

            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public BaseWebServiceResponse Add(AddRoleViewModel model)
        {
            var roleDto = mapper.Map<AddRoleViewModel, RoleDTO>(model);
            var roleNameExists = _roleService.RoleNameExists(roleDto);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = !roleNameExists,
                Error = roleNameExists ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Role Name",
                        Message = "Role Name is already in use."
                    } :
                    null
            };

            if (response.Error != null)
            {
                return response;
            }

            var roleAdded = _roleService.Add(roleDto);

            if (!roleAdded)
            {
                response.ActionSuccessful = false;
                response.Error = roleAdded ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Role",
                        Message = "There was a problem creating the Role. We have been notified of the error but please try again."
                    };
            }

            response.SuccessMessage = "Role added successfully!";
            response.ActionSuccessful = true;
            return response;
        }

        public BaseWebServiceResponse Update(EditRoleViewModel model)
        {
            var roleDto = mapper.Map<EditRoleViewModel, RoleDTO>(model);
            var roleNameExists = _roleService.RoleNameExists(roleDto);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = !roleNameExists,
                Error = roleNameExists ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Role Name",
                        Message = "Role Name is already in use."
                    } :
                    null
            };

            if (response.Error != null)
            {
                return response;
            }

            var roleAdded = _roleService.Update(roleDto);

            if (!roleAdded)
            {
                response.ActionSuccessful = false;
                response.Error = roleAdded ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Role",
                        Message = "There was a problem updating the Role. We have been notified of the error but please try again."
                    };
            }

            response.SuccessMessage = "Role updated successfully!";
            response.ActionSuccessful = true;
            return response;
        }

        public BaseWebServiceResponse Delete(int roleId)
        {
            var roleHasUsers = _roleService.RoleHasUsers(roleId);

            var response = new BaseWebServiceResponse()
            {
                ActionSuccessful = !roleHasUsers,
                Error = roleHasUsers ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Role",
                        Message = "This role is currently linked to active users, please ensure no products are associated with the brand before deletion."
                    } :
                    null
            };

            if (roleHasUsers)
            {
                return response;
            }

            var isRoleDeleted = _roleService.Delete(roleId);

            response.ActionSuccessful = isRoleDeleted;
            response.SuccessMessage = isRoleDeleted ?
                "Role Deleted!" :
                string.Empty;
            response.Error = isRoleDeleted ?
                null :
                new ErrorServiceViewModel
                {
                    Name = "Role",
                    Message = "There was an issue deleting the role. We have been notified of the error but please try again."
                };

            return response;
        }

        public AdminRolesViewModel GetAllRoles()
        {
            var roles = mapper.Map<List<RoleDTO>, List<RoleViewModel>>(_roleService.GetAllRoles());

            return new AdminRolesViewModel
            {
                Roles = roles
            };
        }

        public EditRoleViewModel GetRoleById(int roleId)
        {
            var roleDto = _roleService.GetRoleById(roleId);
            return mapper.Map<RoleDTO, EditRoleViewModel>(roleDto);
        }
    }
}
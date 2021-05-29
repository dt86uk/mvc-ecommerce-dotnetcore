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
            throw new System.NotImplementedException();
        }

        public BaseWebServiceResponse Update(EditRoleViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public BaseWebServiceResponse Delete(int roleId)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
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

        public AdminRolesViewModel GetAllRoles()
        {
            var roles = mapper.Map<List<RoleDTO>, List<RoleViewModel>>(_roleService.GetAllRoles());

            return new AdminRolesViewModel
            {
                Roles = roles
            };
        }
    }
}
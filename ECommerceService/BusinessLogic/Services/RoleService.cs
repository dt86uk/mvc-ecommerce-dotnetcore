using System.Collections.Generic;
using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public List<RoleDTO> GetAllRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            return mapper.Map<List<Role>, List<RoleDTO>>(roles);
        }
    }
}
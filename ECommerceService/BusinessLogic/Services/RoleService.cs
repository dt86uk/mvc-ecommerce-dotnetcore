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

        public bool Add(RoleDTO role)
        {
            var roleEntity = mapper.Map<RoleDTO, Role>(role);
            return _roleRepository.Add(roleEntity);
        }

        public bool Update(RoleDTO role)
        {
            var roleEntity = mapper.Map<RoleDTO, Role>(role);
            return _roleRepository.Update(roleEntity);
        }

        public bool Delete(int roleId)
        {
            return _roleRepository.Delete(roleId);
        }

        public List<RoleDTO> GetAllRoles()
        {
            var listRoleEntities = _roleRepository.GetAllRoles();
            return mapper.Map<List<Role>, List<RoleDTO>>(listRoleEntities);
        }

        public bool RoleHasUsers(int roleId)
        {
            return _roleRepository.RoleHasUsers(roleId);
        }

        public bool RoleNameExists(RoleDTO model)
        {
            var role = mapper.Map<RoleDTO, Role>(model);
            return _roleRepository.RoleNameExists(role);
        }

        public RoleDTO GetRoleById(int roleId)
        {
            var roleEntity = _roleRepository.GetRoleById(roleId);
            return mapper.Map<Role, RoleDTO>(roleEntity);
        }
    }
}
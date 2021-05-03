using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using AutoMapper;

namespace ECommerceService.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public UserDTO CreateUser(UserDTO user)
        {
            var userEntity = mapper.Map<UserDTO, User>(user);
            var createdUser = _userRepository.CreateUser(userEntity);

            return mapper.Map<User, UserDTO>(createdUser);
        }

        public bool IsEmailInUse(string emailAddress)
        {
            return _userRepository.IsEmailInUse(emailAddress);
        }

        /// <summary>
        /// If there is a user, they will be deleted.
        /// </summary>
        /// <param name="newUser"></param>
        public void TryRollbackUser(UserDTO newUser)
        {
            if (newUser == null)
            {
                return;
            }

            _userRepository.DeleteUser(newUser.Id);
        }

        /// <summary>
        /// Gets User by User's Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDTO GetUserById(int userId)
        {
            var userEntity = _userRepository.GetUserById(userId);

            if (userEntity == null)
            {
                return null;
            }

            return mapper.Map<User, UserDTO>(userEntity);
        }

        public bool UpdateUser(UserDTO user)
        {
            var userEntity = mapper.Map<UserDTO, User>(user);
            return _userRepository.UpdateUser(userEntity);
        }

        public List<NewUserDTO> GetLatestNewUsers(int numberOfUsers)
        {
            return mapper.Map<List<User>, List<NewUserDTO>>(_userRepository.GetLatestNewUsers(numberOfUsers));
        }

        public List<UserDetailsDTO> GetAllUsers()
        {
            //TODO: Automapper to sort RoleName from RoleId => Google automapper assign propr based of value of another prop
            var listUsersDetails = mapper.Map<List<User>, List<UserDetailsDTO>>(_userRepository.GetAllUsers());
            var listRoles = mapper.Map<List<Role>, List<RoleDTO>>(_roleRepository.GetAllRoles());

            foreach (var user in listUsersDetails)
            {
                var roleEntity = listRoles.SingleOrDefault(p => p.Id == user.RoleId);
                user.RoleName = roleEntity != null ? roleEntity.RoleName : string.Empty;
            }

            return listUsersDetails;
        }

        public List<RoleDTO> GetAllUserRoles()
        {
            return mapper.Map<List<Role>, List<RoleDTO>>(_roleRepository.GetAllRoles());
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }
}
﻿using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using ECommerceService.Helpers;
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

        public UserDTO Create(UserDTO user)
        {
            var userEntity = mapper.Map<UserDTO, User>(user);
            var createdUser = _userRepository.Create(userEntity);

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

            _userRepository.Delete(newUser.Id);
        }

        /// <summary>
        /// Gets User by User's Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDTO GetUserById(int userId)
        {
            return mapper.Map<User, UserDTO>(_userRepository.GetUserById(userId));
        }

        public bool Update(UserDTO user)
        {
            var userEntity = mapper.Map<UserDTO, User>(user);
            return _userRepository.Update(userEntity);
        }

        public List<NewUserDTO> GetLatestNewUsers(int numberOfUsers)
        {
            return mapper.Map<List<User>, List<NewUserDTO>>(_userRepository.GetLatestNewUsers(numberOfUsers));
        }

        public List<UserDetailsDTO> GetAllUsers()
        {
            var listAllUsers = mapper.Map<List<User>, List<UserDetailsDTO>>(_userRepository.GetAllUsers());
            var listRoles = mapper.Map<List<Role>, List<RoleDTO>>(_roleRepository.GetAllRoles());
            var listUsersDetails = UserHelper.AssignRolesToUsers(listAllUsers, listRoles);

            return listUsersDetails;
        }

        public List<RoleDTO> GetAllUserRoles()
        {
            return mapper.Map<List<Role>, List<RoleDTO>>(_roleRepository.GetAllRoles());
        }

        public bool Delete(int userId)
        {
            return _userRepository.Delete(userId);
        }
    }
}
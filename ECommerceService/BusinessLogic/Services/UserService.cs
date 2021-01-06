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
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
using System;
using AutoMapper;
using Newtonsoft.Json;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models;
using System.Collections.Generic;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class UserWebService : IUserWebService
    {
        private readonly IUserValidationService _userValidationService;
        private readonly IUserService _userService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public UserWebService(IUserValidationService userValidationService, IUserService userService)
        {
            _userValidationService = userValidationService;
            _userService = userService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public BaseUserWebServiceResponse CreateUser(RegisterViewModel model)
        {
            var response = new BaseUserWebServiceResponse();

            if (!_userValidationService.IsDateOfBirthValid(model.DateOfBirthDay,model.DateOfBirthMonth,model.DateOfBirthYear))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth is not valid."
                };
                return response;
            }

            if (!_userValidationService.IsDateOfBirthOver18(int.Parse(model.DateOfBirthDay),int.Parse(model.DateOfBirthMonth),int.Parse(model.DateOfBirthYear)))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
                return response;
            }

            if(!_userValidationService.IsDateOfBirthWithinHumanLivingYears(int.Parse(model.DateOfBirthYear)))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
                return response;
            }

            if (_userValidationService.IsEmailInUse(model.Email))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Email",
                    Message = "Email is already in use."
                };
                return response;
            }

            if (!_userValidationService.IsPasswordValid(model.Password))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Password",
                    Message = "Password does not meet requirements; at least one number, one special character, one upper and lower case and 8 characters minimum."
                };
                return response;
            }

            if (!_userValidationService.DoPasswordsMatch(model.Password, model.ConfirmPassword))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Password",
                    Message = "Password and Confirm Password do not match."
                };
                return response;
            }

            var newUser = _userService.CreateUser(
                new UserDTO()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = new DateTime(
                        Convert.ToInt32(model.DateOfBirthYear),
                        Convert.ToInt32(model.DateOfBirthMonth),
                        Convert.ToInt32(model.DateOfBirthDay)),
                    IsSubscribed = model.IsSubscribed,
                    Password = model.Password
                });

            if (newUser == null || newUser.Id == 0)
            {
                _userService.TryRollbackUser(newUser);
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "User",
                    Message = "There was a problem creating your account. We have been notified of the error but please try again."
                };
                //TODO: Create logging service at Service layer and log error
                return response;
            }

            response.JsonResponseObject = JsonConvert.SerializeObject(newUser);
            response.ActionSuccessful = true;
            return response;
        }

        public AccountViewModel GetUserById(int userId)
        {
            var userDto = _userService.GetUserById(userId);

            return mapper.Map<UserDTO, AccountViewModel>(userDto);
        }

        public bool UpdateUser(AccountViewModel model)
        {
            var userDto = mapper.Map<AccountViewModel, UserDTO>(model);
            return _userService.UpdateUser(userDto);
        }

        public int GetRoleByUserId(int userId)
        {
            return _userService.GetUserById(userId).RoleId;
        }

        public List<NewUserViewModel> GetLatestNewUsers(int numberOfUsers)
        {
            return mapper.Map<List<NewUserDTO>, List<NewUserViewModel>>(_userService.GetLatestNewUsers(numberOfUsers));
        }

        public AdminUsersViewModel GetAllUsers()
        {
            var listUserDetails = mapper.Map<List<UserDetailsDTO>, List<UsersViewModel>>(_userService.GetAllUsers());

            return new AdminUsersViewModel()
            {
                AllUsers = listUserDetails
            };
        }
    }
}
﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using ECommerceWebsite.Helpers;

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

        public BaseWebServiceResponse RegisterUser(RegisterViewModel model)
        {
            var response = new BaseWebServiceResponse
            {
                Error = _userValidationService.ValidateUserDateOfBirth(
                    int.Parse(model.DateOfBirthDay),
                    int.Parse(model.DateOfBirthMonth),
                    int.Parse(model.DateOfBirthYear))
            };

            if (response.Error != null)
            {
                return response;
            }

            if (_userValidationService.IsEmailInUse(model.Email))
            {
                response.Error = new ErrorServiceViewModel()
                {
                    Name = "Email",
                    Message = "Email is already in use."
                };
                return response;
            }

            response.Error = _userValidationService.ValidatePassword(model.Password, model.ConfirmPassword);

            if (response.Error != null)
            {
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
                //TODO: Create logging service at Service layer and log error
                _userService.TryRollbackUser(newUser);
                response.Error = new ErrorServiceViewModel()
                {
                    Name = "User",
                    Message = "There was a problem creating your account. We have been notified of the error but please try again."
                };
                
                return response;
            }

            response.JsonResponseObject = JsonConvert.SerializeObject(newUser);
            response.ActionSuccessful = true;
            return response;
        }

        public BaseWebServiceResponse AddUser(AddUserViewModel model)
        {
            var response = new BaseWebServiceResponse()
            {
                Error = _userValidationService.ValidateUserDateOfBirth(
                    int.Parse(model.DateOfBirthDay),
                    int.Parse(model.DateOfBirthMonth),
                    int.Parse(model.DateOfBirthYear))
            };

            if (response.Error != null)
            {
                return response;    
            }

            if (_userValidationService.IsEmailInUse(model.Email))
            {
                response.Error = new ErrorServiceViewModel()
                {
                    Name = "Email",
                    Message = "Email is already in use."
                };
                return response;
            }

            response.Error = _userValidationService.ValidatePassword(model.Password, model.ConfirmPassword);
            
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
                response.Error = new ErrorServiceViewModel()
                {
                    Name = "User",
                    Message = "There was a problem creating the user. Please try again or contact support."
                };
                //TODO: Create logging service at Service layer and log error
                return response;
            }

            response.ActionSuccessful = true;
            return response;
        }

        public AccountViewModel GetUserById(int userId)
        {
            var userDto = _userService.GetUserById(userId);
            return mapper.Map<UserDTO, AccountViewModel>(userDto);
        }

        public EditUserViewModel GetEditUserModel(int userId)
        {
            var user = _userService.GetUserById(userId);
            var model = mapper.Map<UserDTO, EditUserViewModel>(user);
            model.Roles = SelectListItemHelper.BuildDropDownList(_userService.GetAllUserRoles());

            return model;
        }

        public bool UpdateUser(AccountViewModel model)
        {
            var userDto = mapper.Map<AccountViewModel, UserDTO>(model);
            return _userService.UpdateUser(userDto);
        }

        public BaseWebServiceResponse UpdateUser(EditUserViewModel model)
        {
            var response = new BaseWebServiceResponse
            {
                Error = _userValidationService.ValidateUserDateOfBirth(
                    int.Parse(model.DateOfBirthDay),
                    int.Parse(model.DateOfBirthMonth),
                    int.Parse(model.DateOfBirthYear))
            };

            if (!string.IsNullOrEmpty(model.Password))
            {
                response.Error = _userValidationService.ValidatePassword(model.Password, model.ConfirmPassword);

                if (response.Error != null)
                {
                    return response;
                }
            }

            var userDto = mapper.Map<EditUserViewModel, UserDTO>(model);

            response.ActionSuccessful = _userService.UpdateUser(userDto);
            return response;
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

        public AddUserViewModel GetAddUserModel()
        {
            return new AddUserViewModel()
            {
                Roles = SelectListItemHelper.BuildDropDownList(_userService.GetAllUserRoles())
            };
        }

        public BaseWebServiceResponse DeleteUser(int userId)
        {
            var isUserDeleted = _userService.DeleteUser(userId);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = isUserDeleted,
                Error = new ErrorServiceViewModel()
                {
                    Name = "UserAction",
                    Message = isUserDeleted ?
                        "User Deleted!" :
                        "There was a problem deleting the user!"
                } 
            };

            return response;
        }
    }
}
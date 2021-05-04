using System;
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

        public BaseWebServiceResponse CreateUser(RegisterViewModel model)
        {
            var response = new BaseWebServiceResponse();

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

        //TODO: Refactor this with other Create User
        public BaseWebServiceResponse CreateUser(AddUserViewModel model)
        {
            var response = new BaseWebServiceResponse();

            if (!_userValidationService.IsDateOfBirthValid(model.DateOfBirthDay, model.DateOfBirthMonth, model.DateOfBirthYear))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth is not valid."
                };
                return response;
            }

            if (!_userValidationService.IsDateOfBirthOver18(int.Parse(model.DateOfBirthDay), int.Parse(model.DateOfBirthMonth), int.Parse(model.DateOfBirthYear)))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
                return response;
            }

            if (!_userValidationService.IsDateOfBirthWithinHumanLivingYears(int.Parse(model.DateOfBirthYear)))
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
            var response = new BaseWebServiceResponse();
            var userDto = mapper.Map<EditUserViewModel, UserDTO>(model);

            if (!_userValidationService.IsDateOfBirthValid(model.DateOfBirthDay, model.DateOfBirthMonth, model.DateOfBirthYear))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth is not valid."
                };
                return response;
            }

            if (!_userValidationService.IsDateOfBirthOver18(int.Parse(model.DateOfBirthDay), int.Parse(model.DateOfBirthMonth), int.Parse(model.DateOfBirthYear)))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
                return response;
            }

            if (!_userValidationService.IsDateOfBirthWithinHumanLivingYears(int.Parse(model.DateOfBirthYear)))
            {
                response.Error = new ErrorServiceResponseModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
                return response;
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
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
            }
            
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

        public bool DeleteUser(int userId)
        {
            return _userService.DeleteUser(userId);
        }
    }
}
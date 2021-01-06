using AutoMapper;
using Microsoft.AspNetCore.Http;
using ECommerceWebsite.Models;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public class LoginWebService : ILoginWebService
    {
        private readonly ILoginService _loginService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public LoginWebService(ILoginService loginService)
        {
            _loginService = loginService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public UserViewModel LoginUser(string email, string password)
        {
            var userDto = _loginService.LoginUser(email, password);

            return mapper.Map<UserDTO, UserViewModel>(userDto);
        }

        public void Logout(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
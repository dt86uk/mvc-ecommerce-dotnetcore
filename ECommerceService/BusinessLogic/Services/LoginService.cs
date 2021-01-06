using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public UserDTO LoginUser(string email, string password)
        {
            var userEntity = _loginRepository.LoginUser(email, password);

            return mapper.Map<User, UserDTO>(userEntity);
        }
    }
}
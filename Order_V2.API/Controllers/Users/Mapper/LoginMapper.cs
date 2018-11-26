using Order_V2.API.Controllers.Users.LoginDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Services.Users.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class LoginMapper : ILoginMapper
    {

        private readonly UserAuthenticationServices _userAuthService;
        public LoginMapper(UserAuthenticationServices userAtuhService)
        {
            _userAuthService = userAtuhService;
        }

        public UserSecurity CreateUserSecurity(string login_Pass)
        {
            return _userAuthService.CreateUserSecurity(login_Pass);
        }


        //public LoginUserInformation DTOToLoginUserInfo(LoginRequestDTO loginRequestDTO)
        //{
        //    return new LoginUserInformation(loginRequestDTO.Email, _userAuthService.CreateUserSecurity(loginRequestDTO.Password));
        //}

        //public LoginRequestDTO LoginInfoToDTO(LoginUserInformation loginRequestDTO)
        //{
        //    return new LoginRequestDTO
        //    {
        //        Email = loginRequestDTO.Email
        //    };
        //}








    }
}

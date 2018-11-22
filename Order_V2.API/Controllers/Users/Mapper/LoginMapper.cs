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



        public LoginUserInformation DTOToLoginUserInfo(LoginRequestDTO loginRequestDTO)
        {
            return new LoginUserInformation()
            {
               Email= loginRequestDTO.Email,
               Password= _userAuthService.CreateUserSecurity(loginRequestDTO.Password)
            };
        }

        public LoginRequestDTO LoginInfoToDTO(LoginUserInformation loginRequestDTO)
        {
            return new LoginRequestDTO
            {
                Email = loginRequestDTO.Email
            };
        }








    }
}

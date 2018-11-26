using Order_V2.API.Controllers.Users.LoginDTOs.DTO;
using Order_V2.Domain.Users.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface ILoginMapper
    {
        //LoginInformation DTOToLoginUserInfo(LoginRequestDTO loginRequestDTO);
        //LoginRequestDTO LoginInfoToDTO(LoginInformation loginRequestDTO);
        UserSecurity CreateUserSecurity(string login_Pass);
    }
}

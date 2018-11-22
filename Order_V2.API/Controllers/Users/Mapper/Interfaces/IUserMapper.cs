using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order_V2.API.Controllers.Users.DTO.Users;
using Order_V2.Domain.Users;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface IUserMapper
    {
        List<UserDTO_Return> UserListToDTOReturnList(List<User> userList);
        UserDTO_Return UserToDTOReturn(User user);
    }
}

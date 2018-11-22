using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.DTO.AdministratorDTOs;
using Order_V2.API.Controllers.Users.DTO.Users;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Administrators;
using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class UserMapper : IUserMapper
    {
        private readonly ICustomerMapper _customerMapper;
        private readonly IAdministratorMapper _administratorMapper;

        public UserMapper(ICustomerMapper customerMap, IAdministratorMapper administratorMapper)
        {
            _customerMapper = customerMap;
            _administratorMapper = administratorMapper;
        }


        public List<UserDTO_Return> UserListToDTOReturnList(List<User> userList)
        {
            List<UserDTO_Return> listToReturn = new List<UserDTO_Return>();

            foreach (var item in userList)
            {
                var dto = UserToDTOReturn(item);

                if (dto == null)
                { throw new Exception("could not convert it.."); }

                listToReturn.Add(dto);
            }

            return listToReturn;
        }

        public UserDTO_Return UserToDTOReturn(User user)
        {
            if (user.Discriminator == "Administrator")
            { return _administratorMapper.AdministratorToDTOReturn((Administrator)user); }
            else if (user.Discriminator == "Customer")
            { return _customerMapper.CustomerToDTOReturn((Customer)user); }
            else
            { return null; }
        }
    }
}

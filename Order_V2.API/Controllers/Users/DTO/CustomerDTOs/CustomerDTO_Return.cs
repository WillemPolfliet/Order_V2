using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using Order_V2.API.Controllers.Users.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.CustomerDTOs.DTO
{
    public class CustomerDTO_Return : UserDTO_Return
    {
        public AddressDTO Address { get; set; }
    }
}

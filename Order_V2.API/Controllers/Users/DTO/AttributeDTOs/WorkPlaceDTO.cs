using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.DTO.AttributeDTOs
{
    public class WorkPlaceDTO
    {
        public string OfficeName { get; set; }
        public AddressDTO AddressDTO { get;  set; }
    }
}

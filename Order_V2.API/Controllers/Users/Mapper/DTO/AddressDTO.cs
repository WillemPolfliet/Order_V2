using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.DTO
{
    public class AddressDTO
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public CityDTO CityDTO { get; set; }
    }
}

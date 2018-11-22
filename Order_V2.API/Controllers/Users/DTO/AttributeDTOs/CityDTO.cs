using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.AttributeDTOs.DTO
{
    public class CityDTO
    {
        public int ZIP { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Administrators
{
   public class Administrator_InternalDTO : User_InternalDTO
    {
        public string Workplace_OfficeName { get;  set; }
        public string Workplace_StreetName { get; set; }
        public string Workplace_StreetNumber { get;  set; }
        public int Workplace_City_ZIP { get;  set; }
        public string Workplace_CityName { get; private set; }
        public string Workplace_CountryName { get; private set; }
    }
}


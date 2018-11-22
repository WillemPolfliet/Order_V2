using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Customers
{
    public class Customer_InternalDTO : User_InternalDTO
    {
        public string StreetName { get;  set; }
        public string StreetNumber { get;  set; }
        public int City_ZIP { get;  set; }
        public string CityName { get;  set; }
        public string CountryName { get;  set; }
    }
}

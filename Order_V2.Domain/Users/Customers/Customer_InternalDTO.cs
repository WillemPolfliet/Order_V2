using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Customers
{
    public class Customer_InternalDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Login_Email { get; set; }
        public List<PhoneNumber_InternalDTO> ListOfPhones { get; set; } = new List<PhoneNumber_InternalDTO>();
    }
}

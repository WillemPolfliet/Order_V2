using Order_V2.Domain.Users.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users
{
    public abstract class User_InternalDTO
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Login_Email { get;  set; }
        public UserSecurity UserSecurity { get;  set; }
        public List<string> ListOfPhones { get;  set; } = new List<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Authentication
{
    public class LoginInformation
    {
        public string Email { get; }
        public UserSecurity UserSecurity { get; }

        public LoginInformation(string email, UserSecurity userSecurity)
        {          
            Email = email;
            UserSecurity = userSecurity;
        }
    }
}

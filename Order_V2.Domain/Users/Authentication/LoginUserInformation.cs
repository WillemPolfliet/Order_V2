using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Authentication
{
    public class LoginUserInformation
    {
        public string Email { get; }
        public UserSecurity UserSecurity { get; }

        public LoginUserInformation(string email, UserSecurity userSecurity)
        {
            Email = email;
            UserSecurity = userSecurity;
        }
    }
}

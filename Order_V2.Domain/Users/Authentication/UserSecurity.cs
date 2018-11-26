using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Authentication
{
    public class UserSecurity
    {

        public string Login_HashPass { get; private set; }
        public string Login_Salt { get; private set; }

        //private UserSecurity()
        //{ }

        public UserSecurity(string passwordHashedAndSalted, string appliedSalt)
        {
            Login_HashPass = passwordHashedAndSalted;
            Login_Salt = appliedSalt;
        }
    }
}

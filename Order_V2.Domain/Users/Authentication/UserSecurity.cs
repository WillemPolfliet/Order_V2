using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Authentication
{
    public class UserSecurity
    {

        public string Login_HashPass { get;  }
        public string Login_Salt { get; }

        public UserSecurity(string passwordHashedAndSalted, string appliedSalt)
        {
            Login_HashPass = passwordHashedAndSalted;
            Login_Salt = appliedSalt;
        }
    }
}

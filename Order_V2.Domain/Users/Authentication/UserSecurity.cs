using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Authentication
{
    public class UserSecurity
    {

        public string PasswordHashedAndSalted { get; }
        public string AppliedSalt { get; }

        public UserSecurity(string passwordHashedAndSalted, string appliedSalt)
        {
            PasswordHashedAndSalted = passwordHashedAndSalted;
            AppliedSalt = appliedSalt;
        }

    }
}

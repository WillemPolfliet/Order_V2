using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Order_V2.Services.Users.Security
{
    public class Salter
    {
        public string CreateRandomSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}

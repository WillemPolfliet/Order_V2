using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.DTO.Users
{
    public class UserDTO_Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login_Email { get; set; }
        public string Login_Pass { get; set; }

        public List<string> ListOfPhones { get; set; } = new List<string>();
    }
}

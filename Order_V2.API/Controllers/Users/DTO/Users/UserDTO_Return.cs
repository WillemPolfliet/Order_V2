using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.DTO.Users
{
    public class UserDTO_Return
    {
        public Guid User_ID { get; set; }
        public string Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateEdited { get; set; }
        public string Login_Email { get; set; }
        public List<string> ListOfPhones { get; set; } = new List<string>();
    }
}

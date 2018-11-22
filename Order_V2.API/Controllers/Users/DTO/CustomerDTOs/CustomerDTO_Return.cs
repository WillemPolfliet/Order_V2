using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using Order_V2.API.Controllers.Users.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.CustomerDTOs.DTO
{
    public class CustomerDTO_Return : UserDTO_Return
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateEdited { get; set; }
        public string Login_Email { get; set; }
        public List<string> ListOfPhones { get; set; } = new List<string>();
    }
}

﻿using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.CustomerDTOs.DTO
{
    public class CustomerDTO_Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public string Login_Email { get; set; }
        public List<PhoneNumberDTO> ListOfPhones { get; set; } = new List<PhoneNumberDTO>();
    }
}
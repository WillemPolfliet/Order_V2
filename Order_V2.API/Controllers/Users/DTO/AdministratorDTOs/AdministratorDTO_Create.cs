﻿using Order_V2.API.Controllers.Users.DTO.AttributeDTOs;
using Order_V2.API.Controllers.Users.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.DTO.AdministratorDTOs
{
    public class AdministratorDTO_Create : UserDTO_Create
    {
        public WorkPlaceDTO WorkplaceDTO { get; set; }
    }
}

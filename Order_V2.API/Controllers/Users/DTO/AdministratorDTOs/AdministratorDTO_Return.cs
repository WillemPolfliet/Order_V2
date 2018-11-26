using Order_V2.API.Controllers.Users.DTO.AttributeDTOs;
using Order_V2.API.Controllers.Users.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.DTO.AdministratorDTOs
{
    //als er inheritance in het domain object is, is dit dan een good practice om ook inheritance in de DTO's te doen ?

    public class AdministratorDTO_Return : UserDTO_Return
    {
        public WorkPlaceDTO WorkplaceDTO { get; set; }

    }
}

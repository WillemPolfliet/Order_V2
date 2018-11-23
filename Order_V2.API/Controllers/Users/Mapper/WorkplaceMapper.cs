using Order_V2.API.Controllers.Users.DTO.AttributeDTOs;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class WorkplaceMapper : IWorkplaceMapper
    {
        public Workplace DTOToWorkplace(WorkPlaceDTO WorkplaceDTO)
        {
            throw new NotImplementedException();
        }

        public WorkPlaceDTO WorkplaceToDTO(Workplace Workplace)
        {
            throw new NotImplementedException();
        }
    }
}

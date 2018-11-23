using Order_V2.API.Controllers.Users.DTO.AttributeDTOs;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface IWorkplaceMapper
    {
        Workplace DTOToWorkplace(WorkPlaceDTO WorkplaceDTO);
        WorkPlaceDTO WorkplaceToDTO(Workplace Workplace);
    }
}

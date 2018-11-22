using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface ICityMapper
    {
        City DTOToCity(CityDTO cityDTO);
        CityDTO CityToDTO(City city);
    }
}

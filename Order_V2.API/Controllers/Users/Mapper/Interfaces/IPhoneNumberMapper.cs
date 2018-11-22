using Order_V2.API.Controllers.Users.Mapper.DTO;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface IPhoneNumberMapper
    {
        List<PhoneNumber_InternalDTO> DTOListToPhoneNumpberInternalDTO(List<PhoneNumberDTO> phoneNumberDTOList);
        List<PhoneNumberDTO> PhoneNumpberListToDTO(List<PhoneNumber> phoneNumberList);
    }
}

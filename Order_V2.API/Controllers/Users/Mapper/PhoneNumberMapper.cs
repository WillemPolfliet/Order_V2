using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class PhoneNumberMapper : IPhoneNumberMapper
    {

        public List<PhoneNumber_InternalDTO> DTOListToPhoneNumpberInternalDTO(List<PhoneNumberDTO> phoneNumberDTOList)
        {
            var phoneNumberList_ToReturn = new List<PhoneNumber_InternalDTO>();

            foreach (PhoneNumberDTO item in phoneNumberDTOList)
            {
                var PhoneNumber = DTOToPhoneNumberInternalDTO(item);
                phoneNumberList_ToReturn.Add(PhoneNumber);
            }

            return phoneNumberList_ToReturn;
        }
        private PhoneNumber_InternalDTO DTOToPhoneNumberInternalDTO(PhoneNumberDTO phoneNumberDTO)
        {
            return new PhoneNumber_InternalDTO() { PhoneNumberValue = phoneNumberDTO.PhoneNumberValue };
        }

        public List<PhoneNumberDTO> PhoneNumpberListToDTO(List<PhoneNumber> phoneNumberList)
        {
            var phoneNumberList_ToReturn = new List<PhoneNumberDTO>();

            foreach (PhoneNumber item in phoneNumberList)
            {
                var PhoneNumber = PhoneNumberToDTO(item);
                phoneNumberList_ToReturn.Add(PhoneNumber);
            }

            return phoneNumberList_ToReturn;
        }
        private PhoneNumberDTO PhoneNumberToDTO(PhoneNumber phoneNumber)
        {
            return new PhoneNumberDTO() { PhoneNumberValue = phoneNumber.PhoneNumberValue };
        }     
    }
}

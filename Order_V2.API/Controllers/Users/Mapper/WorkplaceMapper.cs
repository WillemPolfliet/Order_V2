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
        private readonly IAddressMapper _addressMapper;

        public WorkplaceMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }


        public Workplace DTOToWorkplace(WorkPlaceDTO WorkplaceDTO)
        {
            throw new NotImplementedException();
        }

        public WorkPlaceDTO WorkplaceToDTO(Workplace Workplace)
        {
            return new WorkPlaceDTO()
            {
                AddressDTO = _addressMapper.AddressToDTO(Workplace.Address),
                OfficeName = Workplace.OfficeName
            };
        }
    }
}

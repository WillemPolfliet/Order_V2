using Order_V2.API.Controllers.Users.Mapper.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class AddressMapper : IAddressMapper
    {
        private readonly ICityMapper _cityMapper;

        public AddressMapper(ICityMapper cityMapper)
        {
            _cityMapper = cityMapper;
        }

        public AddressDTO AddressToDTO(Address address)
        {
            return new AddressDTO
            {
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                CityDTO = _cityMapper.CityToDTO(address.City)
            };
        }

        public Address DTOToAddress(AddressDTO addressDTO)
        {
            return Address.CreateNewObjectOfAddress(
                addressDTO.StreetName,
                addressDTO.StreetNumber,
                _cityMapper.DTOToCity(addressDTO.CityDTO)
                );
        }
    }
}

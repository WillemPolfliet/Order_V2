﻿using Order_V2.API.Controllers.Users.AttributeDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class CityMapper : ICityMapper
    {
        public CityDTO CityToDTO(City city)
        {
            return new CityDTO() { CityName = city.CityName, CountryName = city.CountryName, ZIP = city.City_ZIP };
        }

        public City DTOToCity(CityDTO cityDTO)
        {
            return City.CreateNewObjectOfCity(cityDTO.ZIP, cityDTO.CityName, cityDTO.CountryName);
        }
    }
}

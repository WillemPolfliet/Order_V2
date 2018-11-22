using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Attributes
{
    public class City
    {
        public int City_ZIP { get; private set; }
        public string CityName { get; private set; }
        public string CountryName { get; private set; }

        private City()
        { }

        private City(int zip, string cityName, string countryName)
        {
            City_ZIP = zip;
            CityName = cityName;
            CountryName = countryName;
        }

        public static City CreateNewObjectOfCity(int zip, string cityName, string country)
        {
            //|| string.IsNullOrWhiteSpace(cityName) || string.IsNullOrWhiteSpace(country)
            //Check is Zip excist in DB
            //var result = _memberService.ZIPExistsInDB(cityDTO.ZIP);

            if (zip.ToString().Length != 4)
            {
                return null;
            }
            return new City(zip, cityName, country);
        }
    }
}


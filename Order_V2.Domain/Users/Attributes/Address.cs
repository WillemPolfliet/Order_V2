using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Attributes
{
    public class Address
    {
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }
        public int City_ZIP { get; private set; }
        public City City { get; private set; }

        private Address()
        { }

        private Address(string streetName, string streetNumber, City givenCity)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            City_ZIP = givenCity.City_ZIP;
            City = givenCity;
        }

        public static Address CreateNewObjectOfAddress(string streetName, string streetNumber, City givenCity)
        {
            return new Address(streetName, streetNumber, givenCity);
        }
    }
}

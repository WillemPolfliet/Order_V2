using Order_V2.Domain.Users.Administrators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Attributes
{
    public class Workplace
    {
        public Guid Workplace_ID { get; private set; }
        public string OfficeName { get; private set; }
        public Address Address { get; private set; }
        public Administrator Administrator { get; private set; }
        
        private Workplace()
        { }

        private Workplace(string officeName, Address address)
        {
            OfficeName = officeName;
            Address = address;
        }

        public static Workplace CreateNewObjectOfWorkplace(string officeName, Address address)
        {
            return new Workplace(officeName, address);
        }
    }
}

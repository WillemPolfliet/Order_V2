using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Attributes
{
    public class PhoneNumber
    {
        public Guid User_ID { get; private set; }
        public string PhoneNumberValue { get; private set; }
        public User User { get; private set; }


        private PhoneNumber()
        { }

        private PhoneNumber(Guid user_ID, string phoneNumberValue)
        {
            User_ID = user_ID;
            PhoneNumberValue = phoneNumberValue;
        }

        public static PhoneNumber CreateNewObjectOfPhoneNumber(Guid customerID, string phoneNumberValue)
        {
            //if (string.IsNullOrWhiteSpace(phoneNumberValue))
            //{
            //    return null;
            //}
            return new PhoneNumber(customerID, phoneNumberValue);
        }
    }
}

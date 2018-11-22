using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Attributes
{
    public class PhoneNumber
    {
        public Guid CustomerID { get; private set; }
        public string PhoneNumberValue { get; private set; }
        public Customer Customer { get; private set; }


        private PhoneNumber()
        { }

        private PhoneNumber(Guid customerID, string phoneNumberValue)
        {
            CustomerID = customerID;
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

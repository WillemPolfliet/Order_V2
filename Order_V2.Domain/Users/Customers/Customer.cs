using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order_V2.Domain.Users.Customers
{
    public class Customer : User
    {
        private static object userSecurity;

        public Address Address { get; private set; }


        private Customer(string firstName, string lastName, Address address, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity) :
            base(registrationDate, dateEdited, firstName, lastName, login_Email, userSecurity)
        {
            Address = address;
        }

        public static Customer CreateNewObjectOfCustomer(string firstName, string lastName, Address address, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity)
        {
            try
            { MailAddress m = new MailAddress(login_Email); }
            catch (FormatException ex)
            { throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Customers"), ex.Message); }

            if (registrationDate > DateTime.Today || dateEdited > DateTime.Today)
            { throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Customers"), "Date Cannot be in the futur"); }

            return new Customer(firstName, lastName, address, login_Email, registrationDate, dateEdited, userSecurity);
        }
    }
}

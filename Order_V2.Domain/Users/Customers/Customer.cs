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
        public Address Address { get; private set; }

        private Customer() : base()
        { }

        private Customer(string Discriminator,string firstName, string lastName, Address address, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity) :
            base(Discriminator, registrationDate, dateEdited, firstName, lastName, login_Email, userSecurity)
        {
            Address = address;
        }

        public static Customer CreateNewObjectOfCustomer(string firstName, string lastName, Address address, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity)
        {
            try
            { MailAddress m = new MailAddress(login_Email); }
            catch (FormatException ex)
            { throw new UserEcxeption(typeof(Customer), ex.Message); }

            if (registrationDate > DateTime.Today || dateEdited > DateTime.Today)
            { throw new UserEcxeption(typeof(Customer), "Date Cannot be in the futur"); }

            var discriminator = typeof(Customer).ToString();
            return new Customer(discriminator, firstName, lastName, address, login_Email, registrationDate, dateEdited, userSecurity);
        }
    }
}

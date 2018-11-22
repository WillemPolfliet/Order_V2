using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order_V2.Domain.Users.Customers
{
    public class Customer 
    {
        public Guid CustomerID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime DateEdited { get; private set; }
        public string Login_Email { get; private set; }
        public List<PhoneNumber> ListOfPhones { get; set; } = new List<PhoneNumber>();


        private Customer()
        { }

        private Customer(string firstName, string lastName, Address address, string login_Email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            RegistrationDate = DateTime.Now;
            DateEdited = DateTime.Now;
            Login_Email = login_Email;
        }

        public static Customer CreateNewObjectOfCustomer(string firstName, string lastName, Address address, string login_Email)
        {
            try
            {
                MailAddress m = new MailAddress(login_Email);
            }
            catch (FormatException ex)
            {
                throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Customers"), ex.Message);
            }

            return new Customer(firstName, lastName, address, login_Email);

        }
    }
}

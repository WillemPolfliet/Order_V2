using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order_V2.Domain.Users
{
    public abstract class User
    {
        public Guid User_ID { get; private set; }
        public string Discriminator { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime DateEdited { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Login_Email { get; private set; }
        public UserSecurity UserSecurity { get; private set; }

        public List<PhoneNumber> ListOfPhones { get; private set; } = new List<PhoneNumber>();

        protected User()
        { }

        protected User(string discriminator,  string firstName, string lastName, string login_Email, UserSecurity userSecurity)
        {
            Discriminator = discriminator;
            RegistrationDate = DateTime.Now;
            DateEdited = DateTime.Now;
            FirstName = firstName;
            LastName = lastName;
            Login_Email = login_Email;
            UserSecurity = userSecurity;
        }

        //if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || address == null || string.IsNullOrWhiteSpace(login_Email))
        //{
        //    return null;
        //}
        //Check Email unique?
    }
}

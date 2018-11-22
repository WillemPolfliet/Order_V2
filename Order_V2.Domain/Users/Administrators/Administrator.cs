using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order_V2.Domain.Users.Administrators
{
    public class Administrator
    {
        public Guid AdministratorID { get; private set; }
        public string Name { get; private set; }
        public string Login_Email { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime DateEdited { get; private set; }
        public string PhoneNumber { get; set; }
        public Workplace Workplace { get; set; }


        private Administrator()
        { }

        private Administrator(string name, string login_Email, Workplace workplace, string phoneNumber)
        {
            Name = name;
            Login_Email = login_Email;
            PhoneNumber = phoneNumber;
            Workplace = workplace;
        }

        public static Administrator CreateNewObjectOfAdministrator(string firstName, string login_Email, Workplace workplace, string phoneNumber)
        {
            try
            {
                MailAddress m = new MailAddress(login_Email);
            }
            catch (FormatException ex)
            {
                throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Administrators"), ex.Message);
            }

            return new Administrator(firstName, login_Email, workplace, phoneNumber);


            //if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || address == null || string.IsNullOrWhiteSpace(login_Email))
            //{
            //    return null;
            //}


        }
    }
}

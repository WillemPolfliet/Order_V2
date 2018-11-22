using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Order_V2.Domain.Users.Administrators
{
    public class Administrator : User
    {
        public Workplace Workplace { get; set; }

        private Administrator(string firstName, string lastName, Workplace workplace, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity) :
            base(registrationDate, dateEdited, firstName, lastName, login_Email, userSecurity)
        {
            Workplace = workplace;
        }

        public static Administrator CreateNewObjectOfAdmùinistrator(string firstName, string lastName, Workplace workplace, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity)
        {       
            try
            { MailAddress m = new MailAddress(login_Email); }
            catch (FormatException ex)
            { throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Administrators"), ex.Message); }

            if (registrationDate > DateTime.Today || dateEdited > DateTime.Today)
            { throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Administrators"), "Date Cannot be in the futur"); }

            return new Administrator(firstName, lastName, workplace, login_Email, registrationDate, dateEdited, userSecurity);
        }
    }
}


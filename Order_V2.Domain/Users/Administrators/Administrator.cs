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
        public Guid Workplace_FK { get; private set; }
        public Workplace Workplace { get; private set; }

        public Administrator() : base()
        { }

        private Administrator(string discriminaotr, string firstName, string lastName, Workplace workplace, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity) :
            base(discriminaotr, registrationDate, dateEdited, firstName, lastName, login_Email, userSecurity)
        {
            Workplace = workplace;
            Workplace_FK = workplace.Workplace_ID;
        }

        public static Administrator CreateNewObjectOfAdmùinistrator(string firstName, string lastName, Workplace workplace, string login_Email, DateTime registrationDate, DateTime dateEdited, UserSecurity userSecurity)
        {
            try
            { MailAddress m = new MailAddress(login_Email); }
            catch (FormatException ex)
            { throw new UserEcxeption(typeof(Administrator), ex.Message); }

            if (registrationDate > DateTime.Today || dateEdited > DateTime.Today)
            { throw new UserEcxeption(typeof(Administrator), "Date Cannot be in the futur"); }

            var discriminator = typeof(Administrator).ToString();
            return new Administrator(discriminator, firstName, lastName, workplace, login_Email, registrationDate, dateEdited, userSecurity);
        }
    }
}


using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Administrators;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order_V2.Services.Users.Interfaces
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        List<Administrator> GetAllAdmins();
        List<Customer> GetAllCustomers();

        Customer RegisterNewCustomer(Customer internalDTO);
        Administrator RegisterNewAdministrator(Administrator internalDTO);

        void AddPhoneNumbersToUserID(List<String> phoneNumbers, Guid givenUser_ID);

         Task<User> GetSingleUserAsync(Guid givenUser_ID);

        //LoginUserInformation FindByLoginEmail(string providedEmail);
    }
}

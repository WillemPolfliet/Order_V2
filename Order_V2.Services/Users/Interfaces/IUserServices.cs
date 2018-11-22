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
        List<Customer> GetAllCustomers();
        Customer RegisterNewCustomerAsync(Customer_InternalDTO internalDTO);
        void AddPhoneNumbersToCostumer(Customer_InternalDTO internalDTO, Customer customer);
        Task<Customer> GetSingleCustomerAsync(Guid CustomerID);
        LoginUserInformation FindByLoginEmailAsync(string providedEmail);
    }
}

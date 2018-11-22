using Microsoft.EntityFrameworkCore;
using Order_V2.Data;
using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Domain.Users.Customers;
using Order_V2.Domain.Users.Exceptions;
using Order_V2.Services.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_V2.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly OrderDbContext _OrderDBContext;
        public UserServices(OrderDbContext orderDBContext)
        {
            _OrderDBContext = orderDBContext;
        }


        public List<Customer> GetAllCustomers()
        {
            var CustomerList = new List<Customer>();
            var CustomerDbSet = _OrderDBContext.Set<Customer>()
                .Include(m => m.Address)
                    .ThenInclude(c => c.City)
                .Include(p => p.ListOfPhones);

            foreach (var customer in CustomerDbSet)
            {
                CustomerList.Add(customer);
            }

            return CustomerList;
        }

        public Customer RegisterNewCustomerAsync(Customer_InternalDTO internalDTO)
        {

            if (string.IsNullOrWhiteSpace(internalDTO.FirstName) || string.IsNullOrWhiteSpace(internalDTO.LastName) || internalDTO.Address == null || string.IsNullOrWhiteSpace(internalDTO.Login_Email))
            { throw new UserEcxeption(Type.GetType("Order_V2.Domain.Users.Customers"), "All fields are required"); }

            Customer newMember = Customer.CreateNewObjectOfCustomer(internalDTO.FirstName, internalDTO.LastName, internalDTO.Address, internalDTO.Login_Email);

            _OrderDBContext.Users.Add(newMember);
            _OrderDBContext.SaveChanges();

            return newMember;
        }

        public void AddPhoneNumbersToCostumer(Customer_InternalDTO internalDTO, Customer customer)
        {
            List<PhoneNumber> phones = new List<PhoneNumber>();
            foreach (var item in internalDTO.ListOfPhones)
            {
                phones.Add(PhoneNumber.CreateNewObjectOfPhoneNumber(customer.CustomerID, item.PhoneNumberValue));
            }
            _OrderDBContext.AddRangeAsync(phones);
            _OrderDBContext.SaveChanges();
        }

        public async Task<Customer> GetSingleCustomerAsync(Guid CustomerID)
        {
            var customer = await _OrderDBContext.Users
                .Include(m => m.Address)
                    .ThenInclude(c => c.City)
                .Include(p => p.ListOfPhones)
                .SingleOrDefaultAsync(x => x.CustomerID == CustomerID);

            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        public async Task<LoginUserInformation> FindByLoginEmailAsync(string providedEmail)
        {
            LoginUserInformation Login = await _OrderDBContext.Users.SingleOrDefaultAsync(x => x.Login_Email == providedEmail);

            if (customer == null)
            {
                return null;
            }

            return Login;
        }








        //public City ZIPExistsInDB(int zip)
        //{
        //    return _OrderDBContext.Set<City>().SingleOrDefault(x => x.ZIP == zip);
        //}
    }
}

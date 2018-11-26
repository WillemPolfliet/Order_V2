using Microsoft.EntityFrameworkCore;
using Order_V2.Data;
using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Administrators;
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

        public async Task<User> GetSingleUserAsync(Guid givenUser_ID)
        {
            var User = await _OrderDBContext.Set<User>().SingleOrDefaultAsync(x => x.User_ID == givenUser_ID);

            if (User == null)
            { return null; }

            return User;
        }

        public List<User> GetAllUsers()
        {
            var Users = new List<User>();

            var AdminDbSet = _OrderDBContext.Set<Administrator>()
                .Include(workplace => workplace.Workplace)
                .ThenInclude(m => m.Address)
                    .ThenInclude(c => c.City)
                .Include(p => p.ListOfPhones)
                .Include(us => us.UserSecurity)
                .ToList();

            var CustomerDbSet = _OrderDBContext.Set<Customer>()
                .Include(m => m.Address)
                    .ThenInclude(c => c.City)
                .Include(p => p.ListOfPhones)
                .Include(us => us.UserSecurity)
                .ToList();


            Users.AddRange(CustomerDbSet);
            Users.AddRange(AdminDbSet);

            return Users;
        }
        public List<Administrator> GetAllAdmins()
        {
            return _OrderDBContext.Set<Administrator>()
                .Include(workplace => workplace.Workplace)
                .ThenInclude(m => m.Address)
                    .ThenInclude(c => c.City)
                .Include(p => p.ListOfPhones)
                .Include(us => us.UserSecurity)
                .ToList();
        }
        public List<Customer> GetAllCustomers()
        {
            return _OrderDBContext.Set<Customer>()
                 .Include(m => m.Address)
                     .ThenInclude(c => c.City)
                 .Include(p => p.ListOfPhones)
                 .Include(us => us.UserSecurity)
                 .ToList();
        }


        public Customer RegisterNewCustomer(Customer newCustomer)
        {
            if (string.IsNullOrWhiteSpace(newCustomer.FirstName) ||
                string.IsNullOrWhiteSpace(newCustomer.LastName) ||
                string.IsNullOrWhiteSpace(newCustomer.Login_Email) ||
                string.IsNullOrWhiteSpace(newCustomer.Address.StreetName) ||
                string.IsNullOrWhiteSpace(newCustomer.Address.StreetNumber) ||
                string.IsNullOrWhiteSpace(newCustomer.Address.City.CountryName) ||
                string.IsNullOrWhiteSpace(newCustomer.Address.City.CityName) ||
                newCustomer.Address.City.City_ZIP <= 0 )
            { throw new UserEcxeption(typeof(Customer), "All fields are required"); }

            if (CheckEmailDuplicate(newCustomer.Login_Email))
            { throw new UserEcxeption(typeof(Customer), "The email already excists"); }

            City cityFromDB = CheckCityInDB(newCustomer.Address.City.City_ZIP, newCustomer.Address.City.CityName, newCustomer.Address.City.CountryName);
            Address newAddress = Address.CreateNewObjectOfAddress(newCustomer.Address.StreetName, newCustomer.Address.StreetNumber, cityFromDB);
            Customer newMember = Customer.CreateNewObjectOfCustomer(newCustomer.FirstName, newCustomer.LastName, newAddress, newCustomer.Login_Email, newCustomer.UserSecurity);

            _OrderDBContext.Customers.Add(newMember);
            _OrderDBContext.SaveChanges();

            return newMember;
        }
        public Administrator RegisterNewAdministrator(Administrator internalDTO)
        {
            //if (string.IsNullOrWhiteSpace(internalDTO.FirstName) ||
            //  string.IsNullOrWhiteSpace(internalDTO.LastName) ||
            //  string.IsNullOrWhiteSpace(internalDTO.Login_Email) ||
            //  string.IsNullOrWhiteSpace(internalDTO.Workplace_StreetName) ||
            //  string.IsNullOrWhiteSpace(internalDTO.Workplace_StreetNumber) ||
            //  string.IsNullOrWhiteSpace(internalDTO.Workplace_OfficeName) ||
            //    string.IsNullOrWhiteSpace(internalDTO.Workplace_CountryName) ||
            //    string.IsNullOrWhiteSpace(internalDTO.Workplace_CityName) ||
            //  internalDTO.Workplace_City_ZIP <= 0 ||
            //  internalDTO.ListOfPhones.Count == 0)
            //{ throw new UserEcxeption(typeof(Customer), "All fields are required"); }

            //if (CheckEmailDuplicate(internalDTO.Login_Email))
            //{ throw new UserEcxeption(typeof(Customer), "The email already excists"); }

            //City cityFromDB = CheckCityInDB(internalDTO.Workplace_City_ZIP, internalDTO.Workplace_CityName, internalDTO.Workplace_CountryName);
            //Address newAddress = Address.CreateNewObjectOfAddress(internalDTO.Workplace_StreetName, internalDTO.Workplace_StreetNumber, cityFromDB);
            //Workplace workplace = Workplace.CreateNewObjectOfWorkplace(internalDTO.Workplace_OfficeName, newAddress);

            //Administrator newMember = Administrator.CreateNewObjectOfAdministrator(internalDTO.FirstName, internalDTO.LastName, workplace, internalDTO.Login_Email, internalDTO.UserSecurity);

            //_OrderDBContext.Administrators.Add(newMember);
            //_OrderDBContext.SaveChanges();

            //return newMember;
            throw new NotImplementedException();
        }      

        private City CheckCityInDB(int city_ZIP, string cityName, string countryName)
        {
            var cityFromDB = _OrderDBContext.Cities.SingleOrDefault(city => city.City_ZIP == city_ZIP);
            if (cityFromDB == null)
            { cityFromDB = City.CreateNewObjectOfCity(city_ZIP, cityName, countryName); }
            return cityFromDB;
        }
        private bool CheckEmailDuplicate(string givenEmail)
        {
            return _OrderDBContext.Users.Any(user => user.Login_Email == givenEmail);
        }



        public void AddPhoneNumbersToUserIDAsync(List<String> phoneNumbers, Guid givenUser_ID)
        {          
            List<PhoneNumber> PhoneNumberListOfUser = new List<PhoneNumber>();
            foreach (var item in phoneNumbers)
            { PhoneNumberListOfUser.Add(PhoneNumber.CreateNewObjectOfPhoneNumber(givenUser_ID, item)); }

             //_OrderDBContext.AddRangeAsync(PhoneNumberListOfUser);
             //_OrderDBContext.SaveChangesAsync();
            
        }




        //public LoginUserInformation FindByLoginEmail(string providedEmail)
        //{
        //    var LoginID = _OrderDBContext.Users.SingleOrDefault(customer => customer.Login_Email == providedEmail);
        //    if (LoginID == null)
        //    { return null; }

        //    var mail = LoginID.Login_Email;
        //    var pass = LoginID.Login_HashPass;
        //    var salt = LoginID.Salt;

        //    LoginUserInformation Login = new LoginUserInformation(mail, new UserSecurity(pass, salt));
        //    return Login;
        //}








        //public City ZIPExistsInDB(int zip)
        //{
        //    return _OrderDBContext.Set<City>().SingleOrDefault(x => x.ZIP == zip);
        //}
    }
}

﻿using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        private readonly IAddressMapper _addressMapper;

        public CustomerMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }


        public List<CustomerDTO_Return> CustomerListToDTOReturnList(List<Customer> CustomerList)
        {
            var CustomerDTO_ReturnList = new List<CustomerDTO_Return>();

            foreach (var customer in CustomerList)
            {
                var CustomerDTO_Return = CustomerToDTOReturn(customer);
                CustomerDTO_ReturnList.Add(CustomerDTO_Return);
            }

            return CustomerDTO_ReturnList;
        }

        public CustomerDTO_Return CustomerToDTOReturn(Customer customer)
        {
            return new CustomerDTO_Return
            {
                User_ID = customer.User_ID,
                Discriminator = customer.Discriminator,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = _addressMapper.AddressToDTO(customer.Address),
                RegistrationDate = customer.RegistrationDate,
                DateEdited = customer.DateEdited,
                Login_Email = customer.Login_Email,
                ListOfPhones = customer.ListOfPhones.Select(x => x.PhoneNumberValue).ToList()
            };
        }




        public Customer_InternalDTO DTOToCustomer_InternalDTO(CustomerDTO_Create customerDTO)
        {
            return new Customer_InternalDTO()
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
               
            };

        }
    }
}

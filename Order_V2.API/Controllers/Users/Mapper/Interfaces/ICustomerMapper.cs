using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.DTO.Users;
using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface ICustomerMapper
    {
        CustomerDTO_Return CustomerToDTOReturn(Customer customer);
        List<CustomerDTO_Return> CustomerListToDTOReturnList(List<Customer> CustomerList);

        //Customer_InternalDTO DTOToCustomer_InternalDTO(CustomerDTO_Create customerDTO);
        
    }
}

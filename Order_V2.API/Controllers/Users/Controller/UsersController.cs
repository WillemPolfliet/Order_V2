using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Services.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ICustomerMapper _customerMapper;

        public UsersController(IUserServices userServices, ICustomerMapper customerMap)
        {
            _userServices = userServices;
            _customerMapper = customerMap;
        }


        [HttpGet]
        public ActionResult<List<CustomerDTO_Return>> GetAllCustomers()
        {
            try
            {
                var customerList = _userServices.GetAllCustomers();
                var toReturn = _customerMapper.CustomerListToDTOReturnList(customerList);
                return Ok(toReturn);
            }
            //catch (UserException ex)
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{CustomerID}")]
        public async Task<ActionResult<CustomerDTO_Return>> GetSingleCustomerAsync([FromRoute] Guid CustomerID)
        {
            try
            {
                var customerList = await _userServices.GetSingleCustomerAsync(CustomerID);
                var toReturn = _customerMapper.CustomerToDTOReturn(customerList);
                return Ok(toReturn);
            }
            //catch (UserException ex)
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateMember(CustomerDTO_Create CustomerDTO)
        {
            try
            {
                var internalDTO = _customerMapper.DTOToCustomer_InternalDTO(CustomerDTO);

                var tempCostumer = _userServices.RegisterNewCustomerAsync(internalDTO);

                _userServices.AddPhoneNumbersToCostumer(internalDTO, tempCostumer);
            }
            //catch (UserException ex)
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}

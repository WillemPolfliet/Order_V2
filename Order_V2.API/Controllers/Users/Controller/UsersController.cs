﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.DTO.AdministratorDTOs;
using Order_V2.API.Controllers.Users.DTO.Users;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users;
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
        private readonly IAdministratorMapper _administratorMapper;
        private readonly IUserMapper _userMapper;

        public UsersController(IUserServices userServices, ICustomerMapper customerMap, IUserMapper userMapper, IAdministratorMapper administratorMapper)
        {
            _userServices = userServices;
            _customerMapper = customerMap;
            _userMapper = userMapper;
            _administratorMapper = administratorMapper;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<List<UserDTO_Return>> GetAllUsers()
        {
            try
            {
                var userList = _userServices.GetAllUsers();
                var toReturn = _userMapper.UserListToDTOReturnList(userList);
                return Ok(toReturn);
            }
            //catch (UserException ex)            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetAllAdministrators")]
        [Authorize(Policy = "AdminOnly")]    
        public ActionResult<List<AdministratorDTO_Return>> GetAllAdmins()
        {
            try
            {
                var adminList = _userServices.GetAllAdmins();
                var toReturn = _administratorMapper.AdministratorListToDTOReturnList(adminList);
                return Ok(toReturn);
            }
            //catch (UserException ex)            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        [AllowAnonymous]
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
        [Route("{UserID}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO_Return>> GetSingleUserAsync([FromRoute] Guid UserID)
        {
            try
            {
                var User = await _userServices.GetSingleUserAsync(UserID);
                var toReturn = _userMapper.UserToDTOReturn(User);

                if (toReturn == null)
                { return BadRequest(); }

                return Ok(toReturn);
            }
            //catch (UserException ex)
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost]
        //[Route("CreateNewCustomer")]
        //public ActionResult<CustomerDTO_Return> RegisterNewCustomerAsync(CustomerDTO_Create CustomerDTO)
        //{
        //    try
        //    {
        //        var internalDTO = _customerMapper.DTOToCustomer_InternalDTO(CustomerDTO);

        //        var registerdCustomer = _userServices.RegisterNewCustomer(internalDTO);

        //        //_userServices.AddPhoneNumbersToUserIDAsync(CustomerDTO.ListOfPhones, internalDTO.User_ID);

        //        return Ok(_customerMapper.CustomerToDTOReturn(registerdCustomer));

        //    }
        //    //catch (UserException ex)
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
            
        //}
        //[HttpPost]
        //[Route("CreateNewAdmin")]
        //public ActionResult RegisterNewAdmin(AdministratorDTO_Create AdminDTO)
        //{
        //    //try
        //    //{
        //    //    var internalDTO = _administratorMapper.DTOToInternalDTO(AdminDTO);
        //    //    _userServices.AddPhoneNumbersToUserID(internalDTO.ListOfPhones, tempAdmin.User_ID);

        //    //    var tempAdmin = _userServices.RegisterNewAdministrator(internalDTO);

        //    //}
        //    ////catch (UserException ex)
        //    //catch (Exception ex)
        //    //{

        //    //    return BadRequest(ex.Message);
        //    //}

        //    return Ok();
        //}
    }
}

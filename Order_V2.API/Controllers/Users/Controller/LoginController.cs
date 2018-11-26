using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_V2.API.Controllers.Users.CustomerDTOs.DTO;
using Order_V2.API.Controllers.Users.LoginDTOs.DTO;
using Order_V2.API.Controllers.Users.Mapper;
using Order_V2.Services.Users;
using Order_V2.Services.Users.Security;

namespace Order_V2.API.Controllers.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly LoginMapper _loginMapper;
        private readonly CustomerMapper _customerMapper;

        private readonly UserServices _userservice;
        private readonly UserAuthenticationServices _userAuthService;

        public LoginController(LoginMapper loginMapper, UserServices userservice, UserAuthenticationServices userAuthService, CustomerMapper customerMapper)
        {
            _loginMapper = loginMapper;
            _userservice = userservice;
            _userAuthService = userAuthService;
            _customerMapper = customerMapper;
        }
        
        [HttpPost]
        [Route("registerNewCustomer")]
        [AllowAnonymous]
        public ActionResult<CustomerDTO_Return> RegisterNewCustomerAsync(CustomerDTO_Create CustomerDTO)
        {
            try
            {
                var internalDTO = _customerMapper.DTOToCustomer_InternalDTO(CustomerDTO);

                var registerdCustomer = _userservice.RegisterNewCustomer(internalDTO);

                //_userServices.AddPhoneNumbersToUserIDAsync(CustomerDTO.ListOfPhones, internalDTO.User_ID);

                return Ok(_customerMapper.CustomerToDTOReturn(registerdCustomer));

            }
            //catch (UserException ex)
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var securityToken = _userAuthService.Authenticate(loginRequestDTO.Email, loginRequestDTO.Password);

            if (securityToken != null)
            {
                return Ok(securityToken.RawData);
            }

            return BadRequest("Email or Password incorrect!");
        }

    }
}
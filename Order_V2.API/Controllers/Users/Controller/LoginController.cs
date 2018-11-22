//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Order_V2.API.Controllers.Users.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {

//        private readonly UserMapper _userMapper;
//        private readonly UserRepository _userRepository;
//        private readonly UserAuthenticationService _userAuthService;

//        public UsersController(UserMapper userMapper, UserRepository userRepository, UserAuthenticationService userAuthService)
//        {
//            _userMapper = userMapper;
//            _userRepository = userRepository;
//            _userAuthService = userAuthService;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public ActionResult Register([FromBody] UserRequestDto userRequestDto)
//        {
//            User user = _userMapper.ToDomain(userRequestDto);
//            _userRepository.Save(user);
//            return Ok();
//        }

//        [HttpPost("authenticate")]
//        [AllowAnonymous]
//        public ActionResult<string> Authenticate([FromBody] UserRequestDto userRequestDto)
//        {
//            var securityToken = _userAuthService.Authenticate(userRequestDto.Email, userRequestDto.Password);

//            if (securityToken != null)
//            {
//                return Ok(securityToken.RawData);
//            }

//            return BadRequest("Email or Password incorrect!");
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Core.Identity;
using ToDoList.Server.Domain;
using ToDoList.Server.Dtos;
using ToDoList.Server.Models;

namespace ToDoList.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _manager;
        private IMapper _mapper;
        private SignInManager<User> _signinManager;
        private readonly JwtSettings _jwtSettings;

        public UserController(JwtSettings  jwtSettings, IMapper mapper,UserManager<User> manager,SignInManager<User> signinManager)
        {
            _manager = manager;

            _mapper = mapper;

            _signinManager = signinManager;

            _jwtSettings = jwtSettings;
        }



        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] CreateConsumer registrationRequest)
        {

            var user = await _manager.FindByEmailAsync(registrationRequest.Email);

            if (user != null)
                throw new Exception($"User with Email : {registrationRequest.Email} already exits");




            var theuser = _mapper.Map<User>(registrationRequest);

            var result = await _manager.CreateAsync(theuser, registrationRequest.Password);


            if (result.Succeeded!)
            {

                return BadRequest(result.Errors.Select(e => e.Description));

            }

            return Ok(GenerateAuthenticationResult(theuser));

        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest
            )
        {


            var user =await _manager.FindByEmailAsync(loginRequest.Email);

            if(user==null)
            {
                return BadRequest();
            }

            var signinresult = await _signinManager.PasswordSignInAsync(loginRequest.Email,loginRequest.Password, false, false);

            if(signinresult.Succeeded!)
            {
                return BadRequest();
            }

                return Ok(GenerateAuthenticationResult(user));
         


        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {

             await _signinManager.SignOutAsync();

            return Ok();
        }

        private AuthenticationResult GenerateAuthenticationResult(User theuser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: theuser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Email, value: theuser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: "id", value: theuser.Id),

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)

            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {

                Sacsess = true,
                Token = tokenHandler.WriteToken(token).ToString(),


            };
        }

       
    }
}

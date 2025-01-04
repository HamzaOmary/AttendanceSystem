using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Services;
using AttendanceSystem.Infrastructure.Repositories;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AttendanceSystem.API.Controllers
{

   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRollRepository _rollRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILoginRepository loginRepository, IRollRepository rollRepository , IUserRepository userRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _rollRepository = rollRepository;
            _userRepository = userRepository;
            _configuration = configuration;
           
    }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            //BCrypt.Net.BCrypt.Verify(model.Password, user.Password)

            if (!string.IsNullOrEmpty(login.Username) && !string.IsNullOrEmpty(login.Password)) 
            {

                // Fetch user from database using the repository  //getbyusername()
                var userLogin = await _loginRepository.GetByUsernameAsync(login.Username);

                var userInfo = await _userRepository.GetUserByIdAsync(userLogin.UserId);

                var userRoll = await _rollRepository.GetRollByIdAsync(userInfo.RollId);

                //check password  if (login.Password == userLogin.Password)
                if (BCrypt.Net.BCrypt.Verify(login.Password , userLogin.Password))
                {
                    //Generat JWT token
                    var token = GenerateJwtToken(userLogin.Username, userRoll.RollName ,userLogin.UserId);
                    return Ok(new LoginResponceModel
                    {
                        token = token
                    });

                }

                //getbyusername()
                //check password
                //if is corect
                //getuserbyid
                //var token = GenerateJwtToken(login.Username);
                //    return Ok(new LoginResponceModel { 
                //        token =token
                //    });
                //else
                //return Unauthorized();
            }
           
            return Unauthorized();
           


            
        }

        //private string GenerateJwtToken(string username, string rollName)
        //{
        //    throw new NotImplementedException();
        //}

        private string GenerateJwtToken(string username, string rollName, int userId )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                //new Claim(ClaimTypes.Sid, userId),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, rollName),
                //new Claim(ClaimTypes.Name,name),
                new Claim(ClaimTypes.Sid,userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
}

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    } 
    public class LoginResponceModel
    {
        public string token { get; set; }
        public string username { get; set; }
        public string userid { get; set; }
        public string userrol { get; set; }
        public string name { get; set; }

    }
}
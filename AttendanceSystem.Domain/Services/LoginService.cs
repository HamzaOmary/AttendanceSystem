using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Services
{
    public class LoginService : ILoginService
    {

            private readonly ILoginRepository _loginRepository;
            //private readonly IConfiguration _configuration;

            public LoginService(ILoginRepository loginRepository )
            {
                _loginRepository = loginRepository;
               // _configuration = configuration;
            }
        
            public async Task<Login> GetLoginByIdAsync(int id)
                {
                    return await _loginRepository.GetLoginByIdAsync(id);
                }

            public async Task<Login> GetLoginByUserIdAsync(int id)
            {
                return await _loginRepository.GetLoginByUserIdAsync(id);
            }

        //public async Task<IEnumerable<Login>> GetAllLoginsAsync()
        //{
        //    return await _loginRepository.GetAllLoginsAsync();
        //}

            public async Task CreateLoginAsync(Login login)
            {
                await _loginRepository.AddLoginAsync(login);
            }

            public async Task UpdateLoginAsync(Login login)
            {
                await _loginRepository.UpdateLoginAsync(login);
            }

            public async Task DeleteLoginAsync(int id)
            {
                await _loginRepository.DeleteLoginAsync(id);
            }

            public async Task UpdatePasswordAsync(UpdateLoginModel model)
            {


                //var NewPsaaword = new Login
                //{
                //    Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword) //model.NewPassword
                //};



                await _loginRepository.UpdatePasswordAsync(model);

                //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // var login = await _loginRepository.GetLoginByUserIdAsync(model.UserId);

                //if (login != null)
                //{
                //    return false;
                //}

                //// Verify the old username and password
                //if (login.Username != model.OldUsername ||!BCrypt.Net.BCrypt.Verify(model.OldPassword, login.Password))
                //{  
                //return false; 
                //}

                // Update the password
                //login.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

                //var NewPass = new Login
                //{

                //    Password = model.NewPassword //BCrypt.Net.BCrypt.HashPassword(model.NewPassword)
                //};

                //await _loginRepository.UpdatePasswordAsync(model);

                    //await _loginRepository.UpdateLoginAsync(login);
                    //await _loginRepository.SaveChangesAsync();

                    //return true;


            }


        //rejester action (dto rejesterdto {name, pass,username, role,dep...})
        //new login{username, pass, user = new user} 
        //await _loginRepository.AddLoginAsync(login);
    }
}

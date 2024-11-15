using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
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

            public LoginService(ILoginRepository loginRepository)
            {
                _loginRepository = loginRepository;
            }

            public async Task<Login> GetLoginByIdAsync(int id)
            {
                return await _loginRepository.GetLoginByIdAsync(id);
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
    }
}

using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface ILoginRepository
    {
        Task<Login> GetLoginByIdAsync(int id);
        Task<Login> GetLoginByUserIdAsync(int id);

       // Task<IEnumerable<Login>> GetAllLoginsAsync();
        Task AddLoginAsync(Login login);
        Task UpdateLoginAsync(Login login);
       // Task UpdatePasswordAsync(UpdateLoginModel model);
        Task UpdatePasswordAsync(UpdateLoginModel model);
        
        Task DeleteLoginAsync(int id);
        Task<Login> GetByUsernameAsync(string username);

    }
}

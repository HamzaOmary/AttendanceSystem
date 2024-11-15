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

       // Task<IEnumerable<Login>> GetAllLoginsAsync();
        Task AddLoginAsync(Login login);
        Task UpdateLoginAsync(Login login);
        Task DeleteLoginAsync(int id);
    }
}

using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface IRollRepository
    {
        Task<Roll> GetRollByIdAsync(int id);
        Task<IEnumerable<Roll>> GetAllRollsAsync();
        Task AddRollAsync(Roll roll);
        Task UpdateRollAsync(Roll roll);
        Task DeleteRollAsync(int id);
    }
}

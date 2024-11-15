using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
    }
}

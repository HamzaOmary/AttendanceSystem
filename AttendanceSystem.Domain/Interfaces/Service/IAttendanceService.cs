using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IAttendanceService
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task CreateAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
    }
}

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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task CreateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            await _attendanceRepository.DeleteAttendanceAsync(id);
        }
    }
}

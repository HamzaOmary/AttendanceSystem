using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            //return await _context.Attendances.FindAsync(id);
            return await _context.Attendances.Where(x => x.AttendanceId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            //_context.Attendances.Update(attendance);
            //await _context.SaveChangesAsync();
            var attendanceToUpdate = await _context.Attendances.Where(x => x.AttendanceId == attendance.AttendanceId).FirstOrDefaultAsync();
            if (attendanceToUpdate != null)
            {

                attendanceToUpdate.Status=attendance.Status;

                 await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendanceToDelete = await _context.Attendances.FindAsync(id);
            if (attendanceToDelete != null)
            {
                _context.Attendances.Remove(attendanceToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
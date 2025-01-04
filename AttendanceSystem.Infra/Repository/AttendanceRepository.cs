using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;

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

        public async Task<List<StudentAttendanceOverviewModel>> GetAttendanceOverviewByIdAsync(int userId)
        {
            // Get all enrollments for the user
            var enrollments = await _context.Enrollments
                .Include(e => e.Section)
                .ThenInclude(s => s.Course)
                .Where(e => e.UserId == userId)
                .ToListAsync();

            var attendanceOverviewList = new List<StudentAttendanceOverviewModel>();

            foreach (var enrollment in enrollments)
            {
                // Calculate total classes
                var totalDays = (enrollment.Section.EndDateTime - enrollment.Section.StartDateTime).Days + 1; // +1 to include the start date
                var totalWeeks = totalDays / 7;
                var totalClasses = totalWeeks * enrollment.Section.Course.CreditHour;

                // Calculate classes attended
                var attendedClasses = await _context.Attendances
                    .Where(a => a.UserId == userId && a.EnrollmentId == enrollment.EnrollmentId)
                    .CountAsync();

                // Calculate attendance percentage
                double attendancePercentage = (totalClasses > 0)
                    ? ((double)attendedClasses / totalClasses) * 100
                    : 0;

                // Add to the result list
                attendanceOverviewList.Add(new StudentAttendanceOverviewModel
                {
                    CourseName = enrollment.Section.Course.CourseName,
                    TotalClasses = totalClasses,
                    ClassesAttended = attendedClasses,
                    AttendancePercentage = Math.Round(attendancePercentage, 2)
                });
            }

            return attendanceOverviewList;
        }


        //public async Task<StudentAttendanceOverviewModel> GetAttendanceOverviewById(int id)
        //{

        //    var classes = await _context.Enrollments.Include(s => s.Section).ThenInclude(c => c.Course).Where(x => x.UserId == id).FirstOrDefaultAsync();
        //    var attendedClasses = await _context.Attendances.Where(x => x.UserId == id && x.EnrollmentId == classes.EnrollmentId).CountAsync();
        //    var courseName = await _context.Enrollments.Include(s => s.Section).ThenInclude(c => c.Course)
        //        .Where(x => x.UserId == id)
        //        //.Select(x => new StudentAttendanceOverviewModel
        //        //        { 
        //        //            CourseName = x.Section.Course.CourseName,
        //        //        }
        //        //)
        //        .FirstOrDefaultAsync();

        //    // Calculate the number of weeks between the start and end date
        //    int totalDays = (classes.Section.EndDateTime - classes.Section.StartDateTime).Days + 1; // +1 to include the start date
        //    int totalWeeks = totalDays / 7;
        //    // Calculate the total number of classes
        //    // Assuming one class per week per credit hour
        //    int totalClasses = totalWeeks * classes.Section.Course.CreditHour;

        //    // Calculate the percentage
        //    double attendancePercentage = ((double)attendedClasses / totalClasses) * 100;


        //    return new StudentAttendanceOverviewModel
        //    {
        //        CourseName = courseName.Section.Course.CourseName,
        //        TotalClasses = totalClasses,
        //        ClassesAttended = attendedClasses,
        //        AttendancePercentage = Math.Round(attendancePercentage, 2)


        //    };
        //}
    }
}
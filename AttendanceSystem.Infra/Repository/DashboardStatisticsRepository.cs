using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Infra.Repository
{
    public class DashboardStatisticsRepository : IDashboardStatisticsRepository
    {
        private readonly AppDbContext _context;

        public DashboardStatisticsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatisticsModel> GetDashboardStatisticsAsync()
        {

           var totalStudents = await _context.Users.CountAsync(u => u.RollId == 2); // Assuming RollId 2 is Student
           var totalTeachers = await _context.Users.CountAsync(u => u.RollId == 3); // Assuming RollId 3 is Teacher
           var totalCourses = await _context.Courses.CountAsync();

           var totalAttendances = await _context.Attendances.CountAsync();
           var totalPresent = await _context.Attendances.CountAsync(a => a.Status == "Present");
           var attendanceRate = totalAttendances > 0 ? (totalPresent * 100.0) / totalAttendances : 0;

            // Fetch attendance data for the week
            var rawAttendance = await _context.Attendances
                .Where(a => a.Date != null && a.Status != null)
                .ToListAsync(); // Fetch data from the database

            var weeklyAttendance = rawAttendance
            .GroupBy(a => a.Date.DayOfWeek)
            .Select(g => new WeeklyAttendance 
            {
                Day = g.Key.ToString(),
                AttendanceRate = g.Count(a => a.Status == "Present") * 100.0 / g.Count()
            })
            .ToList();

            //// Handle potential nulls and empty data
            //var weeklyAttendance = await _context.Attendances
            //        .Where(a => a.Date != null && a.Status != null) // Ensure no null values
            //        .GroupBy(a => a.Date.DayOfWeek)           // Use .Value if Date is nullable
            //        .Select(g => new WeeklyAttendance
            //        {
            //            Day = g.Key.ToString(),
            //            AttendanceRate = g.Count(a => a.Status == "Present") * 100.0 / g.Count()
            //        })
            //        .ToListAsync();

            //var weeklyAttendance = await _context.Attendances
            //    .GroupBy(a => a.Date.DayOfWeek)
            //    .Select(g => new WeeklyAttendance
            //    {
            //        Day = g.Key.ToString(),
            //        AttendanceRate = g.Count(a => a.Status == "Present") * 100.0 / g.Count()
            //    })
            //    .ToListAsync();

            return new DashboardStatisticsModel
                {
                    TotalStudent = totalStudents,
                    TotalTeacher = totalTeachers,
                    TotalCourses = totalCourses,
                    AttendanceRate = attendanceRate,
                    WeeklyAttendance = weeklyAttendance
                };
            

            
            //public async Task<DashboardStatisticsModel> GetDashboardStatistics()
            //{
            //    var result = new DashboardStatisticsModel();
            //    var query = _context.Users.GroupBy(x => x.RollId)
            //        .Select(x => new DashboardStatisticsModel
            //        {
            //            TotalStudent = x.Where(k => k.RollId == 2).Count(),
            //            TotalTeacher = x.Where(k => k.RollId == 3).Count()
            //            //TotalCourses = 0
            //        });

            //    result = await query.FirstOrDefaultAsync();/////////////////////////////
            //    return result;
            //}


        }
    }
}
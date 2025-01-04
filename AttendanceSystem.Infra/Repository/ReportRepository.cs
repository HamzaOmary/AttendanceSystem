using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Attendance>> GetAdminAttendanceReportAsync()
        //{
        //    //var totalAttendances = await _context.Attendances.CountAsync();

        //    //for (int i = 0; i <= totalAttendances; i++)
        //    //{
        //    //    var StudentName = await _context.Users.;
        //    //}

        //    var report = await _context.Attendances
        //        .Include(x => x.User)
        //        .Include(e => e.Enrollment)
        //        .ThenInclude(s => s.Section)
        //        .ThenInclude(c => c.Course)
        //        .Select(a => new AttendanceReportModel
        //        {
        //            StudentName = a.User.FullName,
        //            ReferenceNumber = a.User.ReferanceNumber,
        //            CourseName = a.Enrollment.Section.Course.CourseName,
        //            Date = a.Date,
        //            Status = a.Status
        //        })
        //        .ToListAsync();

        //    return report;


        //    //var teachers = await _context.Attendances.Include(x => x.User)
        //    //        .Select(x => new AttendanceReportModel
        //    //        {
        //    //            Date = x.Date


        //    //        }
        //    //        )
        //    //        .ToListAsync(); // Assuming RollId 2 represents students

        //    //return teachers;

        //}



        public async Task<List<AttendanceReportModel>> GetAdminAttendanceReportAsync(int? courseId, string? studentName, DateTime? startDate, DateTime? endDate)
        {
            var query = from attendance in _context.Attendances
                        join enrollment in _context.Enrollments on attendance.EnrollmentId equals enrollment.EnrollmentId
                        join user in _context.Users on attendance.UserId equals user.UserId
                        join section in _context.Sections on enrollment.SectionId equals section.SectionId
                        join course in _context.Courses on section.CourseId equals course.CourseId
                        where (!courseId.HasValue || course.CourseId == courseId)
                              && (string.IsNullOrEmpty(studentName) || user.FullName.Contains(studentName))
                              && (!startDate.HasValue || attendance.Date >= startDate)
                              && (!endDate.HasValue || attendance.Date <= endDate)
                        select new AttendanceReportModel
                        {
                            StudentName = user.FullName,
                            ReferenceNumber = user.ReferanceNumber,
                            CourseName = course.CourseName,
                            Date = attendance.Date,
                            Status = attendance.Status
                        };

            return await query.ToListAsync();
        }

        public async Task<List<AttendanceReportModel>> GetTeacherAttendanceReportAsync(int teacherId, int? courseId, string? studentName, DateTime? startDate, DateTime? endDate)
        {
            var query = from attendance in _context.Attendances
                        join enrollment in _context.Enrollments on attendance.EnrollmentId equals enrollment.EnrollmentId
                        join user in _context.Users on attendance.UserId equals user.UserId
                        join section in _context.Sections on enrollment.SectionId equals section.SectionId
                        join course in _context.Courses on section.CourseId equals course.CourseId
                        where section.TeacherId == teacherId
                              && (!courseId.HasValue || course.CourseId == courseId)
                              && (string.IsNullOrEmpty(studentName) || user.FullName.Contains(studentName))
                              && (!startDate.HasValue||  attendance.Date >= startDate)
                              && (!endDate.HasValue || attendance.Date <= endDate)
                    select new AttendanceReportModel
                    {
                        StudentName = user.FullName,
                        ReferenceNumber = user.ReferanceNumber,
                        CourseName = course.CourseName,
                        Date = attendance.Date,
                        Status = attendance.Status
                    };

            return await query.ToListAsync();
        }



        //public async Task<List<AttendanceReportModel>> GetTeacherAttendanceReportAsync(int teacherId, int? courseId, string? studentName, DateTime? startDate, DateTime? endDate)
        //{
        //    var query = from attendance in _context.Attendances
        //                join enrollment in _context.Enrollments on attendance.EnrollmentId equals enrollment.EnrollmentId
        //                join user in _context.Users on attendance.UserId equals user.UserId
        //                join section in _context.Sections on enrollment.SectionId equals section.SectionId
        //                join course in _context.Courses on section.CourseId equals course.CourseId
        //                where (!courseId.HasValue || course.CourseId == courseId)
        //                      && (string.IsNullOrEmpty(studentName) || user.FullName.Contains(studentName))
        //                      && (!startDate.HasValue || attendance.Date >= startDate)
        //                      && (!endDate.HasValue || attendance.Date <= endDate)

        //                select new AttendanceReportModel
        //                {
        //                    StudentName = user.FullName,
        //                    ReferenceNumber = user.ReferanceNumber,
        //                    CourseName = course.CourseName,
        //                    Date = attendance.Date,
        //                    Status = attendance.Status
        //                };

        //    return await query.ToListAsync();
        //}


        public async Task<StudentAttendanceReportModel> GetStudentAttendanceReportAsync(int userId)
        {
            // Fetch Subject-Wise Attendance
            var subjectAttendance = await _context.Enrollments
                .Where(e => e.UserId == userId)
                .Include(e => e.Section)
                .ThenInclude(s => s.Course)
                .Select(e => new SubjectAttendanceModel
                {
                    CourseName = e.Section.Course.CourseName,
                    TotalClasses = ((e.Section.EndDateTime - e.Section.StartDateTime).Days / 7) * e.Section.Course.CreditHour,
                    ClassesAttended = _context.Attendances.Count(a => a.UserId == userId && a.EnrollmentId == e.EnrollmentId),
                    AttendancePercentage = Math.Round(
                        (_context.Attendances.Count(a => a.UserId == userId && a.EnrollmentId == e.EnrollmentId) /
                         (double)(((e.Section.EndDateTime - e.Section.StartDateTime).Days / 7) * e.Section.Course.CreditHour)) * 100, 2)
                })
                .ToListAsync();

            // Fetch Date-Wise Attendance
            var dateWiseAttendance = await _context.Attendances
                .Where(a => a.UserId == userId)
                .Include(a => a.Enrollment)
                .ThenInclude(e => e.Section)
                .ThenInclude(s => s.Course)
                .Select(a => new DateWiseAttendanceModel
                {
                    CourseName = a.Enrollment.Section.Course.CourseName,
                    Date = a.Date,
                    Status = a.Status
                })
                .ToListAsync();

            return new StudentAttendanceReportModel
            {
                SubjectAttendance = subjectAttendance,
                DateWiseAttendance = dateWiseAttendance
            };
        }
    }


}


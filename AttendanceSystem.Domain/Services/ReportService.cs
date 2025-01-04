using AttendanceSystem.Domain.DomainModel;
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
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        //public async Task<IEnumerable<AttendanceReportModel>> GetAdminAttendanceReportAsync()
        //{
        //    //var report = await _repository.GetAdminAttendanceReportAsync();
        //    return await _repository.GetAdminAttendanceReportAsync();

        //    //if (user == null)
        //    //{
        //    //    return null;
        //    //}

        //    // Map User entity to GetUserDto
        //    //return new AttendanceReportModel
        //    //{
        //    //    StudentName = 
        //    //};

        //}

       

        public async Task<List<AttendanceReportModel>> GetAdminAttendanceReportAsync(int? courseId, string? studentName, DateTime? startDate, DateTime? endDate)
        {
            return await _repository.GetAdminAttendanceReportAsync(courseId, studentName, startDate, endDate);
        }

        public async Task<List<AttendanceReportModel>> GetTeacherAttendanceReportAsync(int teacherId,int? courseId, string? studentName, DateTime? startDate, DateTime? endDate)
        {
            return await _repository.GetTeacherAttendanceReportAsync(teacherId, courseId, studentName, startDate, endDate);
        }


        public async Task<StudentAttendanceReportModel> GetStudentAttendanceReportAsync(int userId)
        {
            return await _repository.GetStudentAttendanceReportAsync(userId);
        }

    }
}

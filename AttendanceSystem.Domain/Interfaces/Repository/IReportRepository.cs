using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface IReportRepository
    {

        //Task<IEnumerable<Attendance>> GetAdminAttendanceReportAsync();

        Task<List<AttendanceReportModel>> GetAdminAttendanceReportAsync(int? courseId, string? studentName, DateTime? startDate, DateTime? endDate);
        Task<List<AttendanceReportModel>> GetTeacherAttendanceReportAsync(int teacherId,int? courseId, string? studentName, DateTime? startDate, DateTime? endDate);

        Task<StudentAttendanceReportModel> GetStudentAttendanceReportAsync(int userId);
    }
}

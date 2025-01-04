using AttendanceSystem.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IReportService
    {
        // Task<IEnumerable<AttendanceReportModel>> GetAdminAttendanceReportAsync();
        Task<List<AttendanceReportModel>> GetAdminAttendanceReportAsync(int? courseId, string? studentName, DateTime? startDate, DateTime? endDate);
        Task<List<AttendanceReportModel>> GetTeacherAttendanceReportAsync(int teacherId,int? courseId, string? studentName, DateTime? startDate, DateTime? endDate);

        Task<StudentAttendanceReportModel> GetStudentAttendanceReportAsync(int userId);
    }
}

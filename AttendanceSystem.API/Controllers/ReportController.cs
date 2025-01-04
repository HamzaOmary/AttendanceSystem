using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;
using AttendanceSystem.Infrastructure.Repositories;
using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Services;
namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AttendanceReportModel>>> GetAllUsers()
        //{
        //    var report = await _reportService.GetAdminAttendanceReportAsync();
        //    return Ok(report);
        //}                                                                                                                                                   

        [HttpGet("GetAttendanceReport")]
        public async Task<IActionResult> GetAttendanceReport([FromQuery] int? courseId, [FromQuery] string? studentName, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var report = await _reportService.GetAdminAttendanceReportAsync(courseId, studentName, startDate, endDate);
            return Ok(report);
        }

        [HttpGet("TeacherAttendanceReport/{teacherId}")]
        public async Task<ActionResult<IEnumerable<AttendanceReportModel>>> GetTeacherAttendanceReport(
        int teacherId,
        [FromQuery] int? courseId,
        [FromQuery] string? studentName,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
        {
            var report = await _reportService.GetTeacherAttendanceReportAsync(teacherId, courseId, studentName, startDate, endDate);

            if (report == null || report.Count == 0)
            {
                return NotFound("No attendance data found for the specified criteria.");
            }

            return Ok(report);
        }


        [HttpGet("AttendanceReport/{userId}")]
        public async Task<ActionResult<StudentAttendanceReportModel>> GetStudentAttendanceReport(int userId)
        {
            var attendanceReport = await _reportService.GetStudentAttendanceReportAsync(userId);

            if (attendanceReport == null)
            {
                return NotFound();
            }

            return Ok(attendanceReport);
        }

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
                return NotFound();

            return Ok(attendance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAttendance([FromBody] Attendance attendance)
        {
            await _attendanceService.CreateAttendanceAsync(attendance);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.AttendanceId }, attendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
                return BadRequest("Attendance ID mismatch");

            await _attendanceService.UpdateAttendanceAsync(attendance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttendance(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);
            return NoContent();
        }
    }
}
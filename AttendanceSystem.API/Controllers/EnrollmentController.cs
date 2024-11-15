using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEnrollment([FromBody] Enrollment enrollment)
        {
            await _enrollmentService.CreateEnrollmentAsync(enrollment);
            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.EnrollmentId }, enrollment);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateEnrollment(int id, [FromBody] Enrollment enrollment)
        //{
        //    if (id != enrollment.EnrollmentId)
        //        return BadRequest("Enrollment ID mismatch");

        //    await _enrollmentService.UpdateEnrollmentAsync(enrollment);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}
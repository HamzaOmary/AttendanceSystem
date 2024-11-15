using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse([FromBody] Course course)
        {
            await _courseService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateCourse(int id, [FromBody] Course course)
        //{
        //    if (id != course.CourseId)
        //        return BadRequest("Course ID mismatch");

        //    await _courseService.UpdateCourseAsync(course);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
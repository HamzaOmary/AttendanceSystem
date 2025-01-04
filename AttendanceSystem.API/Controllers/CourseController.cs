using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;
using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Services;

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
        public async Task<ActionResult> CreateCourseAsync([FromBody] Course course)
        {
            await _courseService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);

            // Retrieve the created course with only the required fields
            //var createdCourse = await _context.Courses
            //    .Where(c => c.CourseId == course.CourseId)
            //    .Select(c => new
            //    {
            //        //c.CourseId,           // Include CourseId
            //        c.CourseName,         // Include CourseName
            //        c.CourseNumber,       // Include CourseNumber
            //        c.CreditHour,         // Include CreditHour
            //        c.DepartmentId // Flatten the Department's name
            //    })
            //    .FirstOrDefaultAsync();

            //_context.Courses.Add(course);
            //await _context.SaveChangesAsync();

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

        [HttpGet("Courses")]
        public async Task<ActionResult<IEnumerable<ListOfCoursesModel>>> GetListCourses()
        {
            var courses = await _courseService.GetListOfCoursesAsync();
            return Ok(courses);
        }


        [HttpPost("AddCoursetwoAsync")]
        //[Route("AddCoursetwoAsync")]
        public async Task<IActionResult> AddCoursetwoAsync([FromBody] AddCourseModel model)
        {
            //Console.WriteLine($"CourseName: {model.CourseName}, CourseNumber: {model.CourseNumber}, CreditHour: {model.CreditsHour}, DepartmentId: {model.DepartmentId}");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _courseService.AddCoursetwoAsync(model);
            return Ok("Course added successfully.");
        }


        [HttpGet("CourseDropDown")]
        public async Task<ActionResult> GetCourseDropDown()
        {
            var roles = await _courseService.GetCourseDropDownAsync();
            return Ok(roles);
        }
    }

}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<College>>> GetAllColleges()
        {
            var colleges = await _collegeService.GetAllCollegesAsync();
            return Ok

(colleges);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<College>> GetCollegeById(int id)
        {
            var college = await _collegeService.GetCollegeByIdAsync(id);
            if (college == null)
                return NotFound();

            return Ok(college);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCollege([FromBody] College college)
        {
            await _collegeService.CreateCollegeAsync(college);
            return CreatedAtAction(nameof(GetCollegeById), new { id = college.CollegeId }, college);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCollege(int id, [FromBody] College college)
        {
            if (id != college.CollegeId)
                return BadRequest("College ID mismatch");

            await _collegeService.UpdateCollegeAsync(college);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollege(int id)
        {
            await _collegeService.DeleteCollegeAsync(id);
            return NoContent();
        }
    }
}
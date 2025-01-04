using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;
using AttendanceSystem.Domain.DomainModel;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetAllSections()
        {
            var sections = await _sectionService.GetAllSectionsAsync();
            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetSectionById(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);
            if (section == null)
                return NotFound();

            return Ok(section);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSection([FromBody] Section section)
        {
            await _sectionService.CreateSectionAsync(section);
            return CreatedAtAction(nameof(GetSectionById), new { id = section.SectionId }, section);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSection(int id, [FromBody] Section section)
        {
            if (id != section.SectionId)
                return BadRequest("Section ID mismatch");

            await _sectionService.UpdateSectionAsync(section);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSection(int id)
        {
            await _sectionService.DeleteSectionAsync(id);
            return NoContent();
        }

        [HttpGet("TeachingInformation/{teacherId}")]
        public async Task<ActionResult<IEnumerable<TeachingInformationModel>>> GetTeachingInformationByIdAsync(int teacherId)
        {

            var sectionsInfo = await _sectionService.GetTeachingInformationByIdAsync(teacherId);
            if (sectionsInfo == null )
              return NotFound();

            return Ok(sectionsInfo);
        }

        [HttpPost("AddSection")]
        public async Task<ActionResult> AddSection([FromBody] AddSectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Call the service method to add the section
                await _sectionService.AddSectionAsyc(model);
                return Ok(new { message = "Section added successfully" });
            }
            catch (InvalidOperationException ex)
            {
                // If there's a conflict, return a 409 Conflict response
                return Conflict(new { message = ex.Message });
            }

            //await _sectionService.AddSectionAsyc(model);
            //return Ok(new { message = "Section added successfully" });
        }


        //// POST: api/Sections/CheckConflict
        //[HttpPost("CheckConflict")]
        //public async Task<IActionResult> CheckSectionConflict([FromBody] Section section)
        //{
        //    if (section == null)
        //    {
        //        return BadRequest("Invalid section data.");
        //    }

        //    bool hasConflict = await _sectionService.FindSectionConflictAsync(section);

        //    if (hasConflict)
        //    {
        //        return Conflict("The section has a conflict with an existing one.");
        //    }

        //    return Ok("No conflicts found.");
        //}
    }
}
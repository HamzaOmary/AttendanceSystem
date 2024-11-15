using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

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
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        private readonly IRollService _rollService;

        public RollController(IRollService rollService)
        {
            _rollService = rollService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roll>>> GetAllRolls()
        {
            var rolls = await _rollService.GetAllRollsAsync();
            return Ok(rolls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roll>> GetRollById(int id)
        {
            var roll = await _rollService.GetRollByIdAsync(id);
            if (roll == null)
                return NotFound();

            return Ok(roll);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoll([FromBody] Roll roll)
        {
            await _rollService.CreateRollAsync(roll);
            return CreatedAtAction(nameof(GetRollById), new { id = roll.RollId }, roll);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoll(int id, [FromBody] Roll roll)
        {
            if (id != roll.RollId)
                return BadRequest("Roll ID mismatch");

            await _rollService.UpdateRollAsync(roll);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoll(int id)
        {
            await _rollService.DeleteRollAsync(id);
            return NoContent();
        }
    }
}
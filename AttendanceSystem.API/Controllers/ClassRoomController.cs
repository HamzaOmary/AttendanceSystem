using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoom>>> GetAllClassRooms()
        {
            var classRooms = await _classRoomService.GetAllClassRoomsAsync();
            return Ok(classRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRoom>> GetClassRoomById(int id)
        {
            var classRoom = await _classRoomService.GetClassRoomByIdAsync(id);
            if (classRoom == null)
                return NotFound();

            return Ok(classRoom);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClassRoom([FromBody] ClassRoom classRoom)
        {
            await _classRoomService.CreateClassRoomAsync(classRoom);
            return CreatedAtAction(nameof(GetClassRoomById), new { id = classRoom.ClassRoomId }, classRoom);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateClassRoom(int id, [FromBody] ClassRoom classRoom)
        //{
        //    if (id != classRoom.ClassRoomId)
        //        return BadRequest("ClassRoom ID mismatch");

        //    await _classRoomService.UpdateClassRoomAsync(classRoom);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassRoom(int id)
        {
            await _classRoomService.DeleteClassRoomAsync(id);
            return NoContent();
        }
    }
}
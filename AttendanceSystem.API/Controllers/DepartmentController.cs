using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment([FromBody] Department department)
        {
            await _departmentService.CreateDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId }, department);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest("Department ID mismatch");

            await _departmentService.UpdateDepartmentAsync(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}
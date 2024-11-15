using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Login>>> GetAllLogins()
        //{
        //    var logins = await _loginService.GetAllLoginsAsync();
        //    return Ok(logins);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLoginById(int id)
        {
            var login = await _loginService.GetLoginByIdAsync(id);
            if (login == null)
                return NotFound();

            return Ok(login);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLogin([FromBody] Login login)
        {
            await _loginService.CreateLoginAsync(login);
            return CreatedAtAction(nameof(GetLoginById), new { id = login.LoginId }, login);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLogin(int id, [FromBody] Login login)
        {
            if (id != login.LoginId)
                return BadRequest("Login ID mismatch");

            await _loginService.UpdateLoginAsync(login);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLogin(int id)
        {
            await _loginService.DeleteLoginAsync(id);
            return NoContent();
        }
    }
}
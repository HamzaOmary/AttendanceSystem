using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Service;
using AttendanceSystem.Infrastructure.Repositories;
using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Services;
using static System.Net.Mime.MediaTypeNames;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService )
        {
            _userService = userService;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest("User ID mismatch");

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("Students")]
        public async Task<ActionResult<IEnumerable<ListOfStudentModel>>> GetStudents()
        {
            var students = await _userService.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("Teachers")]
        public async Task<ActionResult<IEnumerable<ListOfTeacherModel>>> GetTeachers()
        {
            var teachers = await _userService.GetAllTeacherAsync();
            return Ok(teachers);
        }

        [HttpGet("Student/{id}")]
        //[HttpGet("Student")]
        public async Task<ActionResult> GetStudentInformation(int id)
        {
            var student = await _userService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("Teacher/{id}")]
        //[HttpGet("Student")]
        public async Task<ActionResult> GetTeacherInformation(int id)
        {
            var student = await _userService.GetTeacherByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }



        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        //{
        //    var users = await _userService.GetAllUsersAsync();
        //    return Ok(users);
        //}

        //[HttpPost("add")]
        //public async Task<ActionResult> AddNewUser([FromBody] AddUserModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = string.Join("; ", ModelState.Values
        //            .SelectMany(x => x.Errors)
        //            .Select(x => x.ErrorMessage));
        //        Console.WriteLine($"Validation Errors: {errors}");
        //        return BadRequest(new { Message = "Validation failed", Errors = errors });
        //    }

        //    try
        //    {
        //        var userId = await _userService.AddNewUserAsync(model);
        //        return Ok(new { UserId = userId, Message = "User added successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error adding user: {ex.Message}");
        //        return BadRequest(new { Message = "An error occurred while adding the user.", Details = ex.Message });
        //    }
        //}


        [HttpPost("add")]
        public async Task<ActionResult> AddNewUser([FromBody] AddUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = await _userService.AddNewUserAsync(model);
            return Ok(new { UserId = userId, Message = "User added successfully." });
        }

        //[HttpGet("colleges")]
        //public async Task<ActionResult> GetCollegesName()
        //{
        //    var colleges = await _userService.GetCollegesNameAsync();
        //    return Ok(colleges);
        //}

        //[HttpGet("departments")]
        //public async Task<ActionResult> GetDepartmentsName()
        //{
        //    var departments = await _userService.GetDepartmentsNameAsync();
        //    return Ok(departments);
        //}

        //[HttpGet("roles")]
        //public async Task<ActionResult> GetRolesName()
        //{
        //    var roles = await _userService.GetRolesNameAsync();
        //    return Ok(roles);
        //}

        [HttpGet("UserDropDown")]
        public async Task<ActionResult> GetUsersForDropdown()
        {
            var users = await _userService.GetUserDropDownAsync();
            return Ok(users);
        }

        [HttpGet("TeacherDropDown")]
        public async Task<ActionResult> GetTeacherDropDown()
        {
            var roles = await _userService.GetTeacherDropDownAsync();
            return Ok(roles);
        }
        //C:\\Users\\hammz\\Desktop\\test--2\\Faces\\Image
        //C:\\Users\\hammz\\Desktop\\userImagess

        [HttpPost("AddImage")]
        public IActionResult AddUserImage([FromForm] int userId, [FromForm] IFormFile uploadedFile)
        {
            // Validate the uploaded file
            if (uploadedFile == null || uploadedFile.Length == 0)
                return BadRequest("No file selected.");
            
            // Define the save path
            var folderPath = "C:\\Users\\hammz\\Desktop\\userImagess"; // Update this to your desired folder path
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Name the file using the userId
            var fileName = $"{userId}{Path.GetExtension(uploadedFile.FileName)}";
            var saveFilePath = Path.Combine(folderPath, fileName);

            // Save the file to the folder
            using (var stream = new FileStream(saveFilePath, FileMode.Create))
            {
                uploadedFile.CopyTo(stream);
            }

            // Save the relative path to the database
            var relativePath = Path.Combine("C:/Users/hammz/Desktop/userImagess", fileName).Replace("\\", "/");
        
            _userService.UpdateUserImagePath(userId, relativePath);

            return Ok(new { Message = "Image uploaded successfully.", ImagePath = relativePath });
        }

        [HttpGet("PerformanceOverview/{teacherId}")]
        public async Task<ActionResult<IEnumerable<TeacherPerformanceOverviewModel>>> GetTeacherPerformanceOverviewAsync(int teacherId)
        {
            var performanceData = await _userService.GetTeacherPerformanceOverviewAsync(teacherId);

            if (performanceData == null || !performanceData.Any())
                return NotFound();

            return Ok(performanceData);
        }


    }
}
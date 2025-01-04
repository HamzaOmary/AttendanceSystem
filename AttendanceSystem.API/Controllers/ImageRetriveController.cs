using AttendanceSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageRetriveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImageRetriveController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users/{userId}/Image
        [HttpGet("{userId}/Image")]
        public IActionResult GetUserImage(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            if (string.IsNullOrEmpty(user.UserImag) || !System.IO.File.Exists(user.UserImag))
            {
                return NotFound(new { Message = "Image not found." });
            }

            var imageBytes = System.IO.File.ReadAllBytes(user.UserImag);
            var fileExtension = Path.GetExtension(user.UserImag)?.ToLower();
            string contentType = fileExtension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };

            return File(imageBytes, contentType);
        }
    }
}

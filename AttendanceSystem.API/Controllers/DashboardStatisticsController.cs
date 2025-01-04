using AttendanceSystem.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DashboardStatisticsController : ControllerBase
    {
        private readonly IDashboardStatisticsService _service;

        public DashboardStatisticsController(IDashboardStatisticsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardStatistics()
        {
            var result = await _service.GetDashboardStatisticsAsync();
            return Ok(result);
        }
    }

}


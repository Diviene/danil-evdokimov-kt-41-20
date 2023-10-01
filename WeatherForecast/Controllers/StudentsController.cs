using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Filters.StudentFilters;
using WeatherForecast.Interfaces.StudentFilters;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        { 
        _logger = logger;
        _studentService = studentService;
        }

        [HttpPost(Name = "GetStudentByGroup")]

        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }
    }
}

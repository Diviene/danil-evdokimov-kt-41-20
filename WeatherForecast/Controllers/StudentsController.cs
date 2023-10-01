using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Filters.StudentFilters;
using WeatherForecast.Interfaces.StudentInterfaces;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IGradeService _gradeService;

        public StudentsController(ILogger<StudentsController> logger, IGradeService gradeService)
        { 
        _logger = logger;
        _gradeService = gradeService;
        }


        [HttpPost(Name = "GetGradeByStudent")]
        public async Task<IActionResult> GetGradesByStudentsAsync(StudentGradeFilter filter, CancellationToken cancellationToken = default)
        {
            var grades = await _gradeService.GetGradesByStudentsAsync(filter, cancellationToken);
            return Ok(grades);
        }
    }
}

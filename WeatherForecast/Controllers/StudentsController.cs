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
        private readonly IGroupService _groupService;

        public StudentsController(ILogger<StudentsController> logger, IGroupService gradeService)
        { 
        _logger = logger;
        _groupService = gradeService;
        }


        [HttpPost(Name = "GetListOfGroups")]
        public async Task<IActionResult> GetGradesByStudentsAsync(GroupFilter filter, CancellationToken cancellationToken = default)
        {
            var grades = await _groupService.GetGroupsByNameAsync(filter, cancellationToken);
            return Ok(grades);
        }
    }
}

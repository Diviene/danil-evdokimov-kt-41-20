using Lab3.Database;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Filters.StudentFilters;
using WeatherForecast.Interfaces.StudentInterfaces;

namespace WeatherForecast.Controllers
{
    [ActivatorUtilitiesConstructor]
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGroupService _groupService;
        private StudentDbContext _context;

        public GroupsController(ILogger<GroupsController> logger, IGroupService gradeService, StudentDbContext context)
        {
            _logger = logger;
            _groupService = gradeService;
            _context = context;
        }


        [HttpPost("GetListOfGroups", Name = "GetListOfGroups")]
        public async Task<IActionResult> GetGroupsBySpecialnostAsync(GroupFilter filter, CancellationToken 
            cancellationToken = default)
        {
            var grades = await _groupService.GetGroupsByNameAsync(filter, cancellationToken);
            return Ok(grades);
        }

        [HttpPost("AddGroup", Name = "AddGroup")]
        public IActionResult CreateGroup([FromBody] Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Groups.Add(group);
            _context.SaveChanges();
            return Ok(group);
        }

        [HttpPut("Edit")]
        public IActionResult UpdateGroup(string groupname, [FromBody] GroupFilter updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupname);

            if (existingGroup == null)
            {
                return NotFound();
            }

            existingGroup.DoesExist = updatedGroup.DoesExist;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteGroup(string groupName, Group updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupName);

            if (existingGroup == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(existingGroup);
            _context.SaveChanges();

            return Ok();
        }
    }
}
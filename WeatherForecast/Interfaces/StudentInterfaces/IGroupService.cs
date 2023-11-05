using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Filters.StudentFilters;
using WeatherForecast.Models;

namespace WeatherForecast.Interfaces.StudentInterfaces
{ 
    
        public interface IGroupService
        {
            public Task<Group[]> GetGroupsByNameAsync(GroupFilter filter, CancellationToken cancellationToken);
    }

        public class GroupServices : IGroupService
        {

        private readonly DbContext _dbContext;

        public GroupServices(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Group[]> GetGroupsByNameAsync(GroupFilter filter, CancellationToken cancellationToken = default)
            {
                var grades = _dbContext.Set<Group>().Where(d => d.Specialnosts.SpecialnostName == filter.SpecialnostName && 
                d.GroupYear == filter.GroupYear && d.DoesExist == filter.DoesExist).
                ToArrayAsync(cancellationToken);
                return grades;
            }
    }
}

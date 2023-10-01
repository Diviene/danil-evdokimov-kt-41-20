using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Filters.StudentFilters;

namespace WeatherForecast.Interfaces.StudentFilters
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentServices : IStudentService
    {

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(d => d.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }

        private readonly DbContext _dbContext;

        public StudentServices(StudentDbContext dbContext)
        { 
        _dbContext = dbContext;
        }

        

    }
}

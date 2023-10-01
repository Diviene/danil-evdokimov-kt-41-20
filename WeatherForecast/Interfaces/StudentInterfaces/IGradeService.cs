using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Filters.StudentFilters;

namespace WeatherForecast.Interfaces.StudentInterfaces
{ 
    
        public interface IGradeService
        {
            public Task<Grade[]> GetGradesByStudentsAsync(StudentGradeFilter filter, CancellationToken cancellationToken);
        }

        public class GradeServices : IGradeService
        {

            public Task<Grade[]> GetGradesByStudentsAsync(StudentGradeFilter filter, CancellationToken cancellationToken = default)
            {
                var grades = _dbContext.Set<Grade>().Where(d => d.Student.FirstName + " " + d.Student.LastName + " " + d.Student.SecName == filter.Name).ToArrayAsync(cancellationToken);
                return grades;
            }

            private readonly DbContext _dbContext;

            public GradeServices(StudentDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        }
}

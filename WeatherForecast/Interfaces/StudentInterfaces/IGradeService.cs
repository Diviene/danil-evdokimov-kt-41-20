﻿using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Filters.StudentFilters;

namespace WeatherForecast.Interfaces.StudentInterfaces
{ 
    
        public interface IGroupService
        {
            public Task<Group[]> GetGroupsByNameAsync(StudentGradeFilter filter, CancellationToken cancellationToken);
        }

        public class GroupServices : IGroupService
        {

            public Task<Group[]> GetGroupsByNameAsync(StudentGradeFilter filter, CancellationToken cancellationToken = default)
            {
                var grades = _dbContext.Set<Group>().Where(d => d.Specialnost == filter.Specialnost).Where(d => d.GroupYear == filter.GroupYear).Where(d => d.DoesExist == filter.DoesExist).ToArrayAsync(cancellationToken);
                return grades;
            }

            private readonly DbContext _dbContext;

            public GroupServices(StudentDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        }
}

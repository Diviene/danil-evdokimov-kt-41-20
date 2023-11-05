using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast;
using WeatherForecast.Interfaces.StudentInterfaces;
using WeatherForecast.Models;

namespace danil_evdokimov_kt_41_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "student2")
                .Options;
        }

        [Fact]
        public async Task GetGroupsAsync_KT4120_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new GroupServices(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "КТ-41-20",
                    GroupYear = 2020,
                    DoesExist = true,
                    SpecialnostId = 1
                },
                new Group
                {
                    GroupName = "КТ-42-20",
                    GroupYear = 2020,
                    DoesExist = true,
                    SpecialnostId = 1
                },
                new Group
                {
                    GroupName = "ИВТ-13-18",
                    GroupYear = 2018,
                    DoesExist = false,
                    SpecialnostId = 2
                    
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var spec = new List<Specialnost>
            {
                new Specialnost
                {
                    SpecialnostId = 1,
                    SpecialnostName = "Прикладная информатика"
                },
                new Specialnost
                {
                    SpecialnostId = 2,
                    SpecialnostName = "Вычислительные машины"
                }
            };
            await ctx.Set<Specialnost>().AddRangeAsync(spec);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new WeatherForecast.Filters.StudentFilters.GroupFilter
            {
                SpecialnostName = "Прикладная информатика",
                GroupYear = 2020,
                DoesExist = true
            };
            var studentsResult = await studentService.GetGroupsByNameAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2,studentsResult.Length);

        }
    }
}

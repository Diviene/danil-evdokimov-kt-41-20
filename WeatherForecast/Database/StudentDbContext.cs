using Lab3.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using WeatherForecast;
 
namespace Lab3.Database
{
    public class StudentDbContext : DbContext
    {

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}


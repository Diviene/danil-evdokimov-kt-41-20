using Lab3.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using WeatherForecast;
using WeatherForecast.Database.Configurations;
using WeatherForecast.Models;

namespace Lab3.Database
{
    public class StudentDbContext : DbContext
    {

        public DbSet<Group> Groups { get; set; }
        public DbSet<Specialnost> Specialnosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialnostConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }

}

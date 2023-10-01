using System.Runtime.CompilerServices;
using WeatherForecast.Interfaces.StudentInterfaces;

namespace WeatherForecast.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) { 

            services.AddScoped<IGradeService, GradeServices>();

            return services;
        }
    }
}

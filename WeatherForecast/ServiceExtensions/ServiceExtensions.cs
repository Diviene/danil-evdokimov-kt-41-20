using System.Runtime.CompilerServices;
using WeatherForecast.Interfaces.StudentFilters;

namespace WeatherForecast.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentServices>();

            return services;
        }
    }
}

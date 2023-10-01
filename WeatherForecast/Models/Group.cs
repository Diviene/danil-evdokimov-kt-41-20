using WeatherForecast;

namespace WeatherForecast
{
    public class Group
    {
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
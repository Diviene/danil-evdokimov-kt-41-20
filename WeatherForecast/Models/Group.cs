using WeatherForecast;

namespace WeatherForecast
{
    public class Group
    {
        public int? GroupId { get; set; }
        public string? Specialnost { get; set; }
        public string? GroupName { get; set; }

        public int? GroupYear { get; set; }

        public string DoesExist { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
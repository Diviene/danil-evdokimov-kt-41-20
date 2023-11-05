using System.Text.RegularExpressions;

namespace WeatherForecast.Models
{
    public class Specialnost
    {

        public int SpecialnostId { get; set; }

        public string? SpecialnostName { get; set; }

        public ICollection<Group>? Groups { get; set; }

    }
}

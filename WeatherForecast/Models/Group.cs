using System.Text.RegularExpressions;
using WeatherForecast;
using WeatherForecast.Models;

namespace WeatherForecast
{
    public class Group
    {
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }

        public int? GroupYear { get; set; }

        public bool DoesExist { get; set; }

        public int SpecialnostId { get; set; }

        public Specialnost? Specialnosts { get; set; }

    }

}
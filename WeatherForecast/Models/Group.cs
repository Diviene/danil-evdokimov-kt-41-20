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


        public bool IsValidGroupName() // Проверка формата ввода названия группы
        {
            return Regex.Match(GroupName, @"^[А-Я]-[0-9]{3}-[0-9]{2}$").Success;
        }
    }

}
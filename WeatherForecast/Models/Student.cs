using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherForecast
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SecName { get; set; }
        public int? GroupId { get; set; }

        [DataType(DataType.Date), Display(Name = "DateOfBirth"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        public Group? Group { get; set; }
        public ICollection<Grade>? Grades { get; set; }
        public ICollection<Test>? Tests { get; set; }

        public bool IsAdult(string birthDateString)
        {
            var birthDateRegex = new Regex(@"\d{4}-\d{2}-\d{2}");

            if (!birthDateRegex.IsMatch(birthDateString))
            {
                throw new ArgumentException("birthDateString должен быть в формате yyyy-mm-dd");
            }

            if (!DateTime.TryParse(birthDateString, out var birthDate))
            {
                throw new ArgumentException("birthDateString должен отображать правильную дату");
            }

            var eighteenYearsAgo = DateTime.Today.AddYears(-18);

            return birthDate <= eighteenYearsAgo;
        }
    }
}
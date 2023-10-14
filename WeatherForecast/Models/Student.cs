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
    }
}
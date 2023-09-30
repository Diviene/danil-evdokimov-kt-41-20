using static System.Net.Mime.MediaTypeNames;
using WeatherForecast;

namespace WeatherForecast
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}

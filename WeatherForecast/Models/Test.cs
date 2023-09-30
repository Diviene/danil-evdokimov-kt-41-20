using WeatherForecast;

namespace WeatherForecast
{
    public class Test
    {
        public int TestId { get; set; }

        public string TestName { get; set; }

        public DateTime? DateOfTest { get; set; }

        public string TestCondition { get; set; }

        public int? SubjectId { get; set; }

        public Subject? Subject { get; set; }

        public int? StudentId { get; set; }

        public Student? Student { get; set; }
    }
}

using System.Text.RegularExpressions;


namespace danil_evdokimov_kt_41_20.Tests
{
    public class Adult
    {
            [Fact]
            public void IsAdultTrueWhenStudentIsOver18()
            {
            // Arrange
            var birthDateString = "1999-05-01"; // студенту больше 18 лет

                // Act
                var isAdult = IsAdult(birthDateString);
            
                // Assert
                Assert.True(isAdult, "Студент является совершеннолетним");
            }

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
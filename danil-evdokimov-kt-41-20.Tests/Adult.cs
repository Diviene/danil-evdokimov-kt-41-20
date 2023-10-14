using System.Text.RegularExpressions;


namespace danil_evdokimov_kt_41_20.Tests
{
    public class Adult
    {
            [Fact]
            public void IsAdultTrueWhenStudentIsOver18()
            {
                // Arrange
                var birthDateString = DateTime.Now.AddYears(-20).ToString("yyyy-MM-dd"); // студенту 20 лет

                // Act
                var isAdult = IsAdult(birthDateString);

                // Assert
                Assert.True(isAdult, "Студент является совершеннолетним");
            }

            [Fact]
            public void IsAdultFalseWhenStudentIsUnder18()
            {
            // Arrange
            var birthDateString = DateTime.Now.AddYears(-15).ToString("yyyy-MM-dd"); // студенту "15" лет

            // Act
            var isAdult = IsAdult(birthDateString);

            // Assert
            Assert.False(isAdult, "Студент не является совершеннолетним");
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
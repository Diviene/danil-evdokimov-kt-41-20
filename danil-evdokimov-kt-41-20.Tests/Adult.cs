using System.Text.RegularExpressions;


namespace danil_evdokimov_kt_41_20.Tests
{
    public class Adult
    {
            [Fact]
            public void IsAdultTrueWhenStudentIsOver18()
            {
                // Arrange
                var birthDateString = DateTime.Now.AddYears(-20).ToString("yyyy-MM-dd"); // �������� 20 ���

                // Act
                var isAdult = IsAdult(birthDateString);

                // Assert
                Assert.True(isAdult, "������� �������� ����������������");
            }

            [Fact]
            public void IsAdultFalseWhenStudentIsUnder18()
            {
            // Arrange
            var birthDateString = DateTime.Now.AddYears(-15).ToString("yyyy-MM-dd"); // �������� "15" ���

            // Act
            var isAdult = IsAdult(birthDateString);

            // Assert
            Assert.False(isAdult, "������� �� �������� ����������������");
             }

        public bool IsAdult(string birthDateString)
        {
            var birthDateRegex = new Regex(@"\d{4}-\d{2}-\d{2}");

            if (!birthDateRegex.IsMatch(birthDateString))
            {
                throw new ArgumentException("birthDateString ������ ���� � ������� yyyy-mm-dd");
            }

            if (!DateTime.TryParse(birthDateString, out var birthDate))
            {
                throw new ArgumentException("birthDateString ������ ���������� ���������� ����");
            }

            var eighteenYearsAgo = DateTime.Today.AddYears(-18);

            return birthDate <= eighteenYearsAgo;
        }
    }
}
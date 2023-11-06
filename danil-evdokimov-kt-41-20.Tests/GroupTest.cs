using System.Text.RegularExpressions;
using WeatherForecast.Models;


namespace danil_evdokimov_kt_41_20.Tests
{
    public class GroupTest
    {
        [Fact]
        public void GroupNameTest()
        {
            // Arrange
            var testGroup = new WeatherForecast.Group
            {
                GroupId = 1,
                GroupName = "À-123-20",
                GroupYear = 2020
            };
            // Act
            var result = testGroup.IsValidGroupName();
            // Assert
            Assert.True(result);

        }
       
    }
}
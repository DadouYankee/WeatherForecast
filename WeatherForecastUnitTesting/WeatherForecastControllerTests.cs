using Microsoft.Extensions.Logging;
using Moq;
using WeatherForecast.Controllers;

namespace WeatherForecastUnitTesting
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;
        private readonly WeatherForecastController controller;

        public WeatherForecastControllerTests()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            controller = new WeatherForecastController(_mockLogger.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherForecastController_ShouldThrowArgumentNull_WhenParameterIsNull()
        {
            var controller = new WeatherForecastController(null);
        }

        [TestMethod]
        public void WeatherForecastController_Get_ShouldReturn_WhenParameterIsNull()
        {
            //Arrange
            var expectedResult = new WeatherForecast
            {
                Date = new DateTime(2022, 06, 24),
                TemperatureC = 30,
                Summary = "Freezing"
            };

            //Act
            var result = controller.Get();

            //Assert
            Assert.Equals(result, expectedResult);
        }
    }
}
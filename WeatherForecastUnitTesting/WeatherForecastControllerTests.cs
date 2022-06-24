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
            var expectedDate = new DateTime(2022, 06, 24);

            //Act
            var result = controller.Get();

            //Assert
            Assert.AreEqual(result.Date, expectedDate);
            Assert.AreEqual(result.Summary, "Freezing");
            Assert.AreEqual(result.TemperatureC, 30);

        }
    }
}
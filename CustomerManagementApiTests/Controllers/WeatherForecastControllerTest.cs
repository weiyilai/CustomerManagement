using CustomerManagementApi;
using CustomerManagementApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace CustomerManagementApiTests.Controllers
{
    [TestClass]
    public class WeatherForecastControllerTest
    {
        private ILogger<WeatherForecastController> _logger;

        [TestInitialize]
        public void Init()
        {
            _logger = Substitute.For<ILogger<WeatherForecastController>>();
        }

        [TestMethod]
        public void Test_Returns()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            IEnumerable<WeatherForecast> result = controller.Get();

            // Assert
            var viewResult = result;
            Assert.IsInstanceOfType(viewResult, typeof(IEnumerable<WeatherForecast>));
        }
    }
}

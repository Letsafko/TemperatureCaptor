namespace UnitTest.Domain
{
    using global::Application.Services;
    using Microsoft.Extensions.Options;
    using Xunit;

    public sealed class TemperatureCaptorTest
    {
        [Fact]
        public void Should_return_value_in_right_range()
        {
            //arrange
            var settings = GetTemperatureCaptorSettings();
            var captor = new TemperatureCaptor(Options.Create(settings));

            //act
            var temperature = captor.GenerateNewTemperature();

            //Assert
            Assert.True(temperature >= settings.MinTemperature);
            Assert.True(temperature <= settings.MaxTemperature);
        }

        private static TemperatureCaptorSettings GetTemperatureCaptorSettings()
        {
            return new TemperatureCaptorSettings
            {
                MaxTemperature = 1000,
                MinTemperature = -273.15
            };
        }
    }
}
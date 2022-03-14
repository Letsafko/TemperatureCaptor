using Domain.Strategy;
using Microsoft.Extensions.Options;

namespace UnitTest
{
    internal static class TemperatureConfigurationExtensions
    {
        internal static IOptions<WarmTemperatureRangeSettings> GetWarmTemperatureRange(double temperatureMin = 22, double temperatureMax = 40)
        {
            return Options.Create(new WarmTemperatureRangeSettings
            {
                TemperatureMax = temperatureMax,
                TemperatureMin = temperatureMin
            });
        }

        internal static IOptions<ColdTemperatureSettings> GetColdTemperature(double temperatureMax = 22)
        {
            return Options.Create(new ColdTemperatureSettings
            {
                Temperature = temperatureMax
            });
        }

        internal static IOptions<HotTemperatureSettings> GetHotTemperature(double temperatureMin = 40)
        {
            return Options.Create(new HotTemperatureSettings
            {
                Temperature = temperatureMin
            });
        }
    }
}

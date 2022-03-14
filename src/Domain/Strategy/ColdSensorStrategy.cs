namespace Domain.Strategy
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public sealed class ColdSensorStrategy : IStateSensorStrategy
    {
        private readonly ColdTemperatureSettings _coldTemperatureSettings;
        public ColdSensorStrategy(IOptions<ColdTemperatureSettings> coldTemperatureOptions)
        {
            _coldTemperatureSettings = coldTemperatureOptions.Value;
        }

        private const string Cold = "COLD";
        public Predicate<double> Predicate => temperature => temperature < _coldTemperatureSettings.Temperature;
        public string GetSensorState() => Cold;
    }

    [ExcludeFromCodeCoverage]
    public sealed class ColdTemperatureSettings
    {
        public double Temperature { get; set; }
    }
}

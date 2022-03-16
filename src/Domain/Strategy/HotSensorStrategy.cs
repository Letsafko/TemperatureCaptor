namespace Domain.Strategy
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public sealed class HotSensorStrategy : IStateSensorStrategy
    {
        private readonly HotTemperatureSettings _hotTemperatureSettings;
        public HotSensorStrategy(IOptions<HotTemperatureSettings> hotTemperatureOptions)
        {
            _hotTemperatureSettings = hotTemperatureOptions.Value;
        }

        private const string Hot = "HOT";
        public Predicate<double> Predicate => temperature => temperature > _hotTemperatureSettings.Temperature;
        public string GetSensorState() => Hot;
    }

    [ExcludeFromCodeCoverage]
    public sealed class HotTemperatureSettings
    {
        public double Temperature { get; set; }
    }
}

namespace Domain.Strategy
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public sealed class WarmSensorStrategy : IStateSensorStrategy
    {
        private readonly WarmTemperatureRangeSettings _warmTemperatureRange;
        public WarmSensorStrategy(IOptions<WarmTemperatureRangeSettings> warmTemperatureOptions)
        {
            _warmTemperatureRange = warmTemperatureOptions.Value;
        }

        private const string Warm = "WARM";
        public string GetSensorState() => Warm;
        public Predicate<double> Predicate => temperature => temperature >= _warmTemperatureRange.TemperatureMin &&
                                              temperature <= _warmTemperatureRange.TemperatureMax;

    }

    [ExcludeFromCodeCoverage]
    public sealed class WarmTemperatureRangeSettings
    {
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
    }
}

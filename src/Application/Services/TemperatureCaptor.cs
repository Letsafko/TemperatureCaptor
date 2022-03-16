namespace Application.Services
{
    using Microsoft.Extensions.Options;
    using System;

    public sealed class TemperatureCaptor : ITemperatureCaptor
    {
        private readonly TemperatureCaptorSettings _temperatureCaptorSettings;
        private readonly Random _rng;
        public TemperatureCaptor(IOptions<TemperatureCaptorSettings> temperatureCaptorOptions)
        {
            _temperatureCaptorSettings = temperatureCaptorOptions.Value;
            _rng = new Random();
        }


        public double GenerateNewTemperature()
        {
            var factor = 2.0 * _rng.NextDouble() - 1.0;
            var max = (_temperatureCaptorSettings.MaxTemperature - _temperatureCaptorSettings.MinTemperature) / 2.0;
            var min = (_temperatureCaptorSettings.MaxTemperature + _temperatureCaptorSettings.MinTemperature) / 2.0;

            var temperature = factor * max + min;
            return Math.Round(temperature, 2);
        }
    }

    public sealed class TemperatureCaptorSettings
    {
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entity
{
    [ExcludeFromCodeCoverage]
    public sealed class Sensor
    {
        public Sensor(double temperature, string state)
        {
            Temperature = temperature;
            State = state;
        }

        public double Temperature { get; }
        public string State { get; }
    }
}

using System.Diagnostics.CodeAnalysis;

namespace Application.Boundaries.GetSensorState
{
    [ExcludeFromCodeCoverage]
    public sealed class GetSensorStateOutput
    {
        public GetSensorStateOutput(double temperature, string state)
        {
            Temperature = temperature;
            State = state;
        }

        public double Temperature { get; }
        public string State { get; }
    }
}

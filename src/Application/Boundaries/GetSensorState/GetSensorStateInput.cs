using System.Diagnostics.CodeAnalysis;

namespace Application.Boundaries.GetSensorState
{
    [ExcludeFromCodeCoverage]
    public sealed class GetSensorStateInput
    {
        public GetSensorStateInput(double temperature)
        {
            Temperature = temperature;
        }

        public double Temperature { get; }
    }
}

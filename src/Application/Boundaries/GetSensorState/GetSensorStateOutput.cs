using System.Diagnostics.CodeAnalysis;

namespace Application.Boundaries.GetSensorState
{
    [ExcludeFromCodeCoverage]
    public sealed class GetSensorStateOutput
    {
        public GetSensorStateOutput(string state)
        {
            State = state;
        }

        public string State { get; }
    }
}

using System.Diagnostics.CodeAnalysis;

namespace Application.Boundaries.GetTemperaturesRequested
{
    [ExcludeFromCodeCoverage]
    public sealed class GetTemperaturesRequestedOutput
    {
        public GetTemperaturesRequestedOutput(string state, double temperature)
        {
            Temperature = temperature;
            State = state;
        }

        public double Temperature { get; }
        public string State { get; }
    }
}

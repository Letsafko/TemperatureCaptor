using System.Diagnostics.CodeAnalysis;

namespace Application.Boundaries.GetTemperaturesRequested
{
    [ExcludeFromCodeCoverage]
    public sealed class GetTemperaturesRequestedOutput
    {
        public GetTemperaturesRequestedOutput(string state, string temperature)
        {
            Temperature = temperature;
            State = state;
        }

        public string Temperature { get; }
        public string State { get; }
    }
}

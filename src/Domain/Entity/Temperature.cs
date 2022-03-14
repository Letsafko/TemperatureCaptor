using System.Diagnostics.CodeAnalysis;

namespace Domain.Entity
{
    [ExcludeFromCodeCoverage]
    public sealed class Temperature
    {
        public Temperature(double value, string state)
        {
            Value = value;
            State = state;
        }

        public double Value { get; }
        public string State { get; }
    }
}

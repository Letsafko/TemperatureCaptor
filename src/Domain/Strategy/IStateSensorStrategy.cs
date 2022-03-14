namespace Domain.Strategy
{
    using System;

    public interface IStateSensorStrategy
    {
        Predicate<double> Predicate { get; }
        string GetSensorState();
    }
}

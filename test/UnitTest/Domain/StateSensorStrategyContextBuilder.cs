using Domain.Strategy;
using System.Collections.Generic;
namespace UnitTest.Domain
{
    internal sealed class StateSensorStrategyContextBuilder
    {
        private readonly ICollection<IStateSensorStrategy> _stateSensorStrategies;
        private StateSensorStrategyContextBuilder()
        {
            _stateSensorStrategies = new List<IStateSensorStrategy>();
        }

        internal static StateSensorStrategyContextBuilder Instance =>
            new StateSensorStrategyContextBuilder();

        internal StateSensorStrategyContext Build()
        {
            return new StateSensorStrategyContext(_stateSensorStrategies);
        }

        internal StateSensorStrategyContextBuilder WithStrategy(IStateSensorStrategy strategy)
        {
            _stateSensorStrategies.Add(strategy);
            return this;
        }
    }
}

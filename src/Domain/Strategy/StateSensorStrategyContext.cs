namespace Domain.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class StateSensorStrategyContext : IStateSensorStrategyContext
    {
        private readonly IEnumerable<IStateSensorStrategy> _stateSensorStrategies;
        public StateSensorStrategyContext(IEnumerable<IStateSensorStrategy> stateSensorStrategies)
        {
            _stateSensorStrategies = stateSensorStrategies;
        }

        public IStateSensorStrategy GetStrategy(double temperature)
        {
            return _stateSensorStrategies
                .SingleOrDefault(x => x.Predicate(temperature))
                ?? throw new InvalidOperationException("state sensor strategy not found");
        }
    }
}

namespace Domain.Strategy
{
    public interface IStateSensorStrategyContext
    {
        IStateSensorStrategy GetStrategy(double temperature);
    }
}

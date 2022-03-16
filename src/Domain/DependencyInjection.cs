namespace Domain
{
    using Domain.Strategy;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IStateSensorStrategyContext, StateSensorStrategyContext>();
            services.AddSingleton<IStateSensorStrategy, WarmSensorStrategy>();
            services.AddSingleton<IStateSensorStrategy, ColdSensorStrategy>();
            services.AddSingleton<IStateSensorStrategy, HotSensorStrategy>();

            return services;
        }
    }
}

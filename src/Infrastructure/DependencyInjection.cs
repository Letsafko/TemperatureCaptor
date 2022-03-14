namespace Infrastructure
{
    using Domain.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITemperatureRepository, TemperatureRepository>();
            //services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            return services;
        }
    }
}

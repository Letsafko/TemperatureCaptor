namespace Infrastructure
{
    using Domain.Repository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        private const string Datasource = "temperatures.db";
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITemperatureRepository, TemperatureRepository>();
            services.AddDbContext<SqlLiteContext>(optionsBuilder =>
            {
                optionsBuilder
                .UseSqlite($"Data Source={Datasource}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}

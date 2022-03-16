namespace Infrastructure
{
    using Domain.Repository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        private const string Datasource = "database.db";
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ISensorRepository, SensorRepository>();
            services.AddDbContext<SqliteContext>(optionsBuilder =>
            {
                optionsBuilder
                .UseSqlite($"Data Source={Datasource}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}

using Application;
using Domain;
using Domain.Strategy;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Modules;

namespace WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///  Creates an instance of <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        /// <summary>
        /// Configure service collection.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WarmTemperatureRangeSettings>(_configuration.GetSection("Sensor:State:Warm"));
            services.Configure<ColdTemperatureSettings>(_configuration.GetSection("Sensor:State:Cold"));
            services.Configure<HotTemperatureSettings>(_configuration.GetSection("Sensor:State:Hot"));

            services
                .AddInfrastructureServices()
                .AddApplicationServices()
                .AddDomainServices()
                .AddPresenters()
                .AddMediator()
                .AddSwagger();

            services.AddControllers();
        }

        /// <summary>
        /// Configgure application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCustomSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SqlLiteContext>();
                context.Database.Migrate();
            }
        }
    }
}

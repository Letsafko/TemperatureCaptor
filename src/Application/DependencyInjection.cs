namespace Application
{
    using Application.UseCases;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<Boundaries.GetTemperaturesRequested.IUseCase, GetTemperaturesRequestedUseCase>();
            services.AddScoped<Boundaries.GetSensorState.IUseCase, GetSensorStateUseCase>();

            return services;
        }
    }
}

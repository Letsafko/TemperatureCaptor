namespace WebApi.Modules
{
    using Application.Boundaries.GetSensorState;
    using Microsoft.Extensions.DependencyInjection;
    using WebApi.UseCases.GetSensorState;
    using WebApi.UseCases.GetTemperaturesRequested;

    internal static class UserInterfaceExtensions
    {
        internal static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<GetSensorStatePresenter, GetSensorStatePresenter>();
            services.AddScoped<IOutputPort>(x => x.GetRequiredService<GetSensorStatePresenter>());

            services.AddScoped<GetTemperaturesRequestedPresenter, GetTemperaturesRequestedPresenter>();
            services.AddScoped<Application.Boundaries.GetTemperaturesRequested.IOutputPort>(x => x.GetRequiredService<GetTemperaturesRequestedPresenter>());

            return services;
        }
    }
}

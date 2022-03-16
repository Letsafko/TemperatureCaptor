namespace WebApi.Modules
{
    using Application.Boundaries.GetSensorState;
    using Application.Boundaries.GetTemperaturesRequested;
    using FluentMediator;
    using Microsoft.Extensions.DependencyInjection;

    internal static class FluentMediatorExtensions
    {
        internal static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<GetSensorStateInput>().PipelineAsync()
                        .Call<Application.Boundaries.GetSensorState.IUseCase>((handler, request) => handler.ExecuteAsync(request));

                    builder.On<GetTemperaturesRequestedInput>().PipelineAsync()
                        .Call<Application.Boundaries.GetTemperaturesRequested.IUseCase>((handler, request) => handler.ExecuteAsync(request));
                });

            return services;
        }
    }
}

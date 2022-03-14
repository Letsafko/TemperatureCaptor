using Application.UseCases;
using Domain.Entity;
using Domain.Repository;
using Domain.Strategy;
using Infrastructure;
using UnitTest.Domain;
using WebApi.UseCases.GetSensorState;

namespace UnitTest.Application.UseCases.GetSensorState
{

    internal sealed class GetSensorStateUseCaseBuilder
    {
        private readonly IStateSensorStrategyContext _stateSensorStrategyContext;
        private ITemperatureRepository _temperatureRepository;
        private readonly GetSensorStatePresenter _presenter;
        private readonly SqlLiteContext _sqliteContext;

        private GetSensorStateUseCaseBuilder()
        {
            _stateSensorStrategyContext = StateSensorStrategyContextBuilder
                .Instance
                .WithStrategy(new WarmSensorStrategy(TemperatureConfigurationExtensions.GetWarmTemperatureRange()))
                .WithStrategy(new ColdSensorStrategy(TemperatureConfigurationExtensions.GetColdTemperature()))
                .WithStrategy(new HotSensorStrategy(TemperatureConfigurationExtensions.GetHotTemperature()))
                .Build();

            _sqliteContext = SqlLiteContextExtensions.GetInMemoryContext();
            _temperatureRepository = new TemperatureRepository(_sqliteContext);
            _presenter = new GetSensorStatePresenter();
        }

        internal static GetSensorStateUseCaseBuilder Instance =>
            new GetSensorStateUseCaseBuilder();

        internal GetSensorStateUseCase Build()
        {
            return new GetSensorStateUseCase(_stateSensorStrategyContext,
                _temperatureRepository,
                _presenter);
        }

        internal GetSensorStateUseCaseBuilder WithPresenter(out GetSensorStatePresenter presenter)
        {
            presenter = _presenter;
            return this;
        }

        internal GetSensorStateUseCaseBuilder WithAddTemperature(Temperature temperature)
        {
            _temperatureRepository.AddTemperatureAsync(temperature).Wait();
            return this;
        }
    }
}

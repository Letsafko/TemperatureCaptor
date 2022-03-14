namespace Application.UseCases
{
    using Application.Boundaries.GetSensorState;
    using Domain.Entity;
    using Domain.Repository;
    using Domain.Services;
    using Domain.Strategy;
    using System.Threading.Tasks;

    public sealed class GetSensorStateUseCase : IUseCase
    {
        private readonly IStateSensorStrategyContext _stateSensorStrategyContext;
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly ITemperatureConverter _temperatureConverter;
        private readonly IOutputPort _outputPort;
        public GetSensorStateUseCase(IStateSensorStrategyContext stateSensorStrategyContext,
            ITemperatureRepository temperatureRepository,
            ITemperatureConverter temperatureConverter,
            IOutputPort outputPort)
        {
            _stateSensorStrategyContext = stateSensorStrategyContext;
            _temperatureRepository = temperatureRepository;
            _temperatureConverter = temperatureConverter;
            _outputPort = outputPort;
        }

        public async Task ExecuteAsync(GetSensorStateInput input)
        {
            var temperatureInCelsius = _temperatureConverter.ToCelsius(input.Temperature);
            var sensorState = _stateSensorStrategyContext
                .GetStrategy(temperatureInCelsius)
                .GetSensorState();

            var temperatureToSave = new Temperature(temperatureInCelsius, sensorState);
            await _temperatureRepository.AddTemperatureAsync(temperatureToSave);

            _outputPort.Standard(new GetSensorStateOutput(sensorState));
        }
    }
}

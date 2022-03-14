namespace Application.UseCases
{
    using Application.Boundaries.GetSensorState;
    using Domain.Entity;
    using Domain.Repository;
    using Domain.Strategy;
    using System.Threading.Tasks;

    public sealed class GetSensorStateUseCase : IUseCase
    {
        private readonly IStateSensorStrategyContext _stateSensorStrategyContext;
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly IOutputPort _outputPort;
        public GetSensorStateUseCase(IStateSensorStrategyContext stateSensorStrategyContext,
            ITemperatureRepository temperatureRepository,
            IOutputPort outputPort)
        {
            _stateSensorStrategyContext = stateSensorStrategyContext;
            _temperatureRepository = temperatureRepository;
            _outputPort = outputPort;
        }

        private const double ZeroAbsolu = -273.15;
        private const double MaxTempCelsius = 100;
        public async Task ExecuteAsync(GetSensorStateInput input)
        {
            if (input.Temperature < ZeroAbsolu || input.Temperature > MaxTempCelsius)
            {
                _outputPort.WriteError("not valid celsius temperature.");
                return;
            }

            var sensorState = _stateSensorStrategyContext
                .GetStrategy(input.Temperature)
                .GetSensorState();

            var temperatureToSave = new Temperature(input.Temperature, sensorState);
            await _temperatureRepository.AddTemperatureAsync(temperatureToSave);

            _outputPort.Standard(new GetSensorStateOutput(sensorState));
        }
    }
}

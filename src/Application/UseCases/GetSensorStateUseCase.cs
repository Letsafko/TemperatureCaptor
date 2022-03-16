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
        private readonly ISensorRepository _sensorRepository;
        private readonly IOutputPort _outputPort;
        public GetSensorStateUseCase(IStateSensorStrategyContext stateSensorStrategyContext,
            ISensorRepository sensorRepository,
            IOutputPort outputPort)
        {
            _stateSensorStrategyContext = stateSensorStrategyContext;
            _sensorRepository = sensorRepository;
            _outputPort = outputPort;
        }

        private const double ZeroAbsolu = -273.15;
        public async Task ExecuteAsync(GetSensorStateInput input)
        {
            if (input.Temperature < ZeroAbsolu)
            {
                _outputPort.WriteError($"{input.Temperature} not valid celsius temperature.");
                return;
            }

            var sensorState = _stateSensorStrategyContext
                .GetStrategy(input.Temperature)
                .GetSensorState();

            var temperatureToSave = new Sensor(input.Temperature, sensorState);
            await _sensorRepository.AddNewSensorAsync(temperatureToSave);

            _outputPort.Standard(new GetSensorStateOutput(input.Temperature, sensorState));
        }
    }
}

namespace Application.UseCases
{
    using Application.Boundaries.GetTemperaturesRequested;
    using Domain.Entity;
    using Domain.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class GetTemperaturesRequestedUseCase : IUseCase
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly IOutputPort _outputPort;
        public GetTemperaturesRequestedUseCase(ITemperatureRepository temperatureRepository,
            IOutputPort outputPort)
        {
            _temperatureRepository = temperatureRepository;
            _outputPort = outputPort;
        }

        public async Task ExecuteAsync(GetTemperaturesRequestedInput input)
        {
            var temperatures = await _temperatureRepository.GetLastTemperaturesAsync(input.PageSize);
            var temperaturesConverted = Convert(temperatures);

            _outputPort.Standard(temperaturesConverted.ToList());
        }

        private static IEnumerable<GetTemperaturesRequestedOutput> Convert(IEnumerable<Temperature> temperatures)
        {
            foreach (var temperature in temperatures)
            {
                yield return new GetTemperaturesRequestedOutput(temperature.State,
                    $"{temperature.Value} °c");
            }
        }
    }
}

using Application.Boundaries.GetSensorState;
using Application.UseCases;
using Domain.Entity;
using Domain.Repository;
using Domain.Services;
using Domain.Strategy;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTest.Domain;

namespace UnitTest.Application.UseCases.GetSensorState
{

    internal sealed class GetSensorStateUseCaseBuilder
    {
        private readonly IList<Mock> _mocks;
        private readonly IStateSensorStrategyContext _stateSensorStrategyContext;
        private readonly Mock<ITemperatureRepository> _temperatureRepository;
        private readonly ITemperatureConverter _temperatureConverter;
        private readonly Mock<IOutputPort> _outputPort;

        private GetSensorStateUseCaseBuilder()
        {
            _stateSensorStrategyContext = StateSensorStrategyContextBuilder
                .Instance
                .WithStrategy(new WarmSensorStrategy(TemperatureConfigurationExtensions.GetWarmTemperatureRange()))
                .WithStrategy(new ColdSensorStrategy(TemperatureConfigurationExtensions.GetColdTemperature()))
                .WithStrategy(new HotSensorStrategy(TemperatureConfigurationExtensions.GetHotTemperature()))
                .Build();

            _temperatureRepository = new Mock<ITemperatureRepository>(MockBehavior.Strict);
            _temperatureConverter = new TemperatureConverter();
            _outputPort = new Mock<IOutputPort>();
            _mocks = new List<Mock>();
        }

        internal static GetSensorStateUseCaseBuilder Instance =>
            new GetSensorStateUseCaseBuilder();

        internal GetSensorStateUseCase Build(List<Mock> mocks = null)
        {
            mocks?.AddRange(_mocks);
            return new GetSensorStateUseCase(_stateSensorStrategyContext,
                _temperatureRepository.Object,
                _temperatureConverter,
                _outputPort.Object);
        }

        internal GetSensorStateUseCaseBuilder WithPresenter(GetSensorStateOutput outpout)
        {
            _mocks.Add(_outputPort);
            var returns = _outputPort.Setup(x => x.Standard(It.Is<GetSensorStateOutput>(y => CompareSensorStateOutpout(y, outpout))));

#pragma warning disable CS0618
            returns
                .AtMostOnce()
                .Verifiable();
#pragma warning restore CS0618

            return this;
        }

        internal GetSensorStateUseCaseBuilder WithAddTemperature(Temperature temperature)
        {
            _mocks.Add(_temperatureRepository);
            var returns = _temperatureRepository.Setup(x => x.AddTemperatureAsync(It.Is<Temperature>(y => CompareTemperature(y, temperature))))
                .Returns(Task.CompletedTask);

#pragma warning disable CS0618
            returns
                .AtMostOnce()
                .Verifiable();
#pragma warning restore CS0618

            return this;
        }

        private static bool CompareTemperature(Temperature expected, Temperature actual)
        {
            expected.ShouldBeEquivalentTo(actual);
            return true;
        }

        private static bool CompareSensorStateOutpout(GetSensorStateOutput expected, GetSensorStateOutput actual)
        {
            expected.ShouldBeEquivalentTo(actual);
            return true;
        }
    }
}

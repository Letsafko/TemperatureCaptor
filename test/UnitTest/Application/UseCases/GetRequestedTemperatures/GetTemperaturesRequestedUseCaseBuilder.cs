namespace UnitTest.Application.UseCases.GetRequestedTemperatures
{
    using global::Application.Boundaries.GetTemperaturesRequested;
    using global::Application.UseCases;
    using global::Domain.Entity;
    using global::Domain.Repository;
    using Moq;
    using Shouldly;
    using System.Collections.Generic;

    internal sealed class GetTemperaturesRequestedUseCaseBuilder
    {
        private readonly List<Mock> _mocks;
        private readonly Mock<ITemperatureRepository> _temperatureRepository;
        private readonly Mock<IOutputPort> _outputPort;

        private GetTemperaturesRequestedUseCaseBuilder()
        {
            _temperatureRepository = new Mock<ITemperatureRepository>(MockBehavior.Strict);
            _outputPort = new Mock<IOutputPort>(MockBehavior.Strict);
            _mocks = new List<Mock>();
        }

        internal static GetTemperaturesRequestedUseCaseBuilder Instance
            => new GetTemperaturesRequestedUseCaseBuilder();

        internal GetTemperaturesRequestedUseCase Build(List<Mock> mocks = null)
        {
            mocks?.AddRange(_mocks);
            return new GetTemperaturesRequestedUseCase(_temperatureRepository.Object,
                _outputPort.Object);
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithGetTemperatures(int pageSize, List<Temperature> temperatures)
        {
            _mocks.Add(_temperatureRepository);
            var returns = _temperatureRepository.Setup(x => x.GetTemperaturesAsync(pageSize))
                .ReturnsAsync(temperatures);

#pragma warning disable CS0618
            returns
                .AtMostOnce()
                .Verifiable();
#pragma warning restore CS0618

            return this;
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithPresenter(List<GetTemperaturesRequestedOutput> temperatureOutput)
        {
            _mocks.Add(_outputPort);
            var returns = _outputPort
                .Setup(x => x.Standard(It.Is<List<GetTemperaturesRequestedOutput>>(y => CompareRequestedTemperaturesOutpout(y, temperatureOutput))));

#pragma warning disable CS0618
            returns
                .AtMostOnce()
                .Verifiable();
#pragma warning restore CS0618

            return this;
        }

        private static bool CompareRequestedTemperaturesOutpout(List<GetTemperaturesRequestedOutput> expected,
            List<GetTemperaturesRequestedOutput> actual)
        {
            for (var i = 0; i < expected.Count; i++)
            {
                expected[i].ShouldBeEquivalentTo(actual[i]);
            }
            return true;
        }
    }
}
